import EntityRepository from "./entity-repository.js";
import proto from "./proto.js";

export default class WebSocket {
    constructor(url, token) {
        this.connection = new ReconnectingWebSocket(url);
        this.connection.binaryType = 'arraybuffer';

        this.entityRepository = new EntityRepository(this);

        this.connection.onopen = () => {
            const authEvent = proto.AuthEvent.create({token: token});
            const clientEvent = proto.ClientEvent.create({auth: authEvent});
            const buffer = proto.ClientEvent.encode(clientEvent).finish();
            this.connection.send(buffer);
        };

        this.connection.onerror = (error) => {
            console.log("err", error);
        };

        this.connection.onmessage = async (e) => {
            const serverEvent = proto.ServerEvent.decode(new Uint8Array(await new Response(e.data).arrayBuffer()));
            const obj = proto.ServerEvent.toObject(serverEvent, {
                defaults: true
            });
            //console.log('event ' + JSON.stringify(obj));
            if (obj.send != null) {
                const entities = obj.send.entities;
                this.entityRepository.setEntities(entities);
            } else if (obj.dataChange != null) {
                const dataChange = obj.dataChange;
                if (this.entityRepository.entities.has(dataChange.id)) {
                    const entity = this.entityRepository.entities.get(dataChange.id);
                    if (!entity.data) {
                        entity.data = {};
                    }
                    entity.data[dataChange.key] = dataChange.value;
                    const newEntity = this.entityRepository.entities.get(dataChange.id);
                    //console.log("data changed", newEntity.id, newEntity.data);
                    if (this.entityRepository.isStreamedIn(dataChange.id)) {
                        delete dataChange.id;
                        alt.emit("dataChange", JSON.stringify({
                            entity: newEntity,
                            data: dataChange
                        }));
                    }
                }
            } else if (obj.positionChange) {
                const positionChange = obj.positionChange;
                if (this.entityRepository.entities.has(positionChange.id)) {
                    const entity = this.entityRepository.entities.get(positionChange.id);
                    entity.position = positionChange.position;
                    this.entityRepository.updateWorker();
                    //TODO: update only changed entity
                    //console.log("position changed", entity.id, entity.position);
                }
            } else if (obj.rangeChange) {
                const rangeChange = obj.rangeChange;
                if (this.entityRepository.entities.has(rangeChange.id)) {
                    const entity = this.entityRepository.entities.get(rangeChange.id);
                    entity.range = rangeChange.range;
                    this.entityRepository.updateWorker();
                    //TODO: update only changed entity
                    //console.log("range changed", entity.id, entity.range);
                }
            } else if (obj.delete) {
                const deleteEvent = obj.delete;
                if (deleteEvent) {
                    this.entityRepository.removeEntity(deleteEvent.id);
                }
            } else if (obj.create) {
                const createEvent = obj.create;
                if (createEvent.entity) {
                    this.entityRepository.addEntity(createEvent.entity);
                }
            } else if (obj.multipleDataChange) {
                const multipleDataChange = obj.multipleDataChange;
                //console.log(JSON.stringify(multipleDataChange));
                if (this.entityRepository.entities.has(multipleDataChange.id)) {
                    const entity = this.entityRepository.entities.get(multipleDataChange.id);
                    if (!entity.data) {
                        entity.data = {};
                    }
                    for (const key in multipleDataChange.data) {
                        if (multipleDataChange.data.hasOwnProperty(key)) {
                            entity.data[key] = multipleDataChange.data[key];
                        }
                    }
                    const newEntity = this.entityRepository.entities.get(multipleDataChange.id);
                    //console.log("multiple data change", newEntity.id, newEntity.data);
                    if (this.entityRepository.isStreamedIn(multipleDataChange.id)) {
                        alt.emit("dataChange", JSON.stringify({
                            entity: newEntity,
                            data: multipleDataChange.data
                        }));
                    }
                }
            } else if (obj.dimensionChange) {
                const dimensionChange = obj.dimensionChange;
                if (this.entityRepository.entities.has(dimensionChange.id)) {
                    const entity = this.entityRepository.entities.get(dimensionChange.id);
                    entity.dimension = dimensionChange.dimension;
                    this.entityRepository.updateWorker();
                    //console.log("dimension changed", entity.id, entity.dimension);
                }
            }
        };
    }

    sendEvent(event) {
        const clientEvent = proto.ClientEvent.create(event);
        const buffer = proto.ClientEvent.encode(clientEvent).finish();
        this.connection.send(buffer);
    }
}