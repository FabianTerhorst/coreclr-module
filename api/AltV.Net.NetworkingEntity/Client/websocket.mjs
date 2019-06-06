import EntityRepository from "./entity-repository.mjs";
import proto from "./proto.mjs";

class WebSocket {
    constructor() {
        this.connection = new ReconnectingWebSocket('ws://localhost:46429');
        this.connection.binaryType = 'arraybuffer';

        this.entityRepository = new EntityRepository(this);

        this.connection.onopen = () => {
            proto.getProto().then((proto) => {
                const authEvent = proto.AuthEvent.create({token: "123"});
                const clientEvent = proto.ClientEvent.create({auth: authEvent});
                const buffer = proto.ClientEvent.encode(clientEvent).finish();
                this.connection.send(buffer);
            });
        };

        this.connection.onerror = (error) => {
            console.log("err", error);
        };

        this.connection.onmessage = (e) => {
            proto.getProto().then(async (proto) => {
                const serverEvent = proto.ServerEvent.decode(new Uint8Array(await new Response(e.data).arrayBuffer()));
                const obj = proto.ServerEvent.toObject(serverEvent, {
                    defaults: true
                });
                console.log('event', obj, serverEvent);
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
                        console.log("data changed", entity.id, entity.data);
                    }
                } else if (obj.positionChange) {
                    const positionChange = obj.positionChange;
                    if (this.entityRepository.entities.has(positionChange.id)) {
                        const entity = this.entityRepository.entities.get(positionChange.id);
                        entity.position = positionChange.position;
                        this.entityRepository.updateWorker();
                        console.log("position changed", entity.id, entity.position);
                    }
                } else if (obj.rangeChange) {
                    const rangeChange = obj.rangeChange;
                    if (this.entityRepository.entities.has(rangeChange.id)) {
                        const entity = this.entityRepository.entities.get(rangeChange.id);
                        entity.range = rangeChange.range;
                        this.entityRepository.updateWorker();
                        console.log("range changed", entity.id, entity.range);
                    }
                } else if (obj.delete) {
                    const deleteEvent = obj.delete;
                    if (this.entityRepository.entities.delete(deleteEvent.id)) {
                        this.entityRepository.updateWorker();
                        console.log("entity deleted", deleteEvent.id);
                    }
                } else if (obj.create) {
                    const createEvent = obj.create;
                    if (createEvent.entity) {
                        this.entityRepository.entities.set(createEvent.entity.id, createEvent.entity);
                        this.entityRepository.updateWorker();
                    }
                } else if (obj.multipleDataChange) {
                    const multipleDataChange = obj.multipleDataChange;
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
                        console.log("multiple data change", this.entityRepository.entities.get(multipleDataChange.id).data);
                    }
                } else if (obj.dimensionChange) {
                    const dimensionChange = obj.dimensionChange;
                    if (this.entityRepository.entities.has(dimensionChange.id)) {
                        const entity = this.entityRepository.entities.get(dimensionChange.id);
                        entity.dimension = dimensionChange.dimension;
                        this.entityRepository.updateWorker();
                        console.log("dimension changed", entity.id, entity.dimension);
                    }
                }
            });
        };
    }

    sendEvent(event) {
        proto.getProto().then((proto) => {
            const clientEvent = proto.ClientEvent.create(event);
            const buffer = proto.ClientEvent.encode(clientEvent).finish();
            this.connection.send(buffer);
        })
    }
}

export default new WebSocket();