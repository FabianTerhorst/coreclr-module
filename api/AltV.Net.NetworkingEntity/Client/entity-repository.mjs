import playerPosition from "./player-position.mjs"
import proto from "./proto.mjs"

export default class EntityRepository {
    constructor(websocket) {
        this.websocket = websocket;
        // entity-id, entity
        this.entities = new Map();
        this.streamedInEntities = new Map();
        this.streamingWorker = new Worker('streaming-worker.mjs');
        playerPosition.update = (position) => {
            this.updateWorker();
        };
        this.streamingWorker.onmessage = event => {
            console.log(event.data);
            const streamIn = event.data.streamIn;
            const streamOut = event.data.streamOut;
            if (streamIn) {
                this.addStreamedInEntity(streamIn);
                proto.getProto().then((proto) => {
                    websocket.sendEvent({ streamIn:  proto.EntityStreamInEvent.create({ entityId: streamIn.id })})
                });
                try {
                    alt.emit("networkingEntityStreamIn", streamIn);
                } catch (e) {
                    console.log(e);
                }
            } else if (streamOut) {
                this.removeStreamedInEntity(streamOut);
                proto.getProto().then((proto) => {
                    websocket.sendEvent({ streamOut:  proto.EntityStreamOutEvent.create({ entityId: streamOut.id })})
                });
                try {
                    alt.emit("networkingEntityStreamOut", streamOut);
                } catch (e) {
                    console.log(e);
                }
            }
        };
    }

    getEntities() {
        return this.entities.values();
    }

    getStreamedInEntities() {
        return this.streamedInEntities;
    }

    setEntities(entities) {
        let newEntities = new Map();
        for (const entity of entities) {
            newEntities.set(entity.id, entity);
        }
        this.entities = newEntities;
        this.updateWorker();
    }

    addStreamedInEntity(entity) {
        this.streamedInEntities.set(entity.id, entity);
    }

    removeStreamedInEntity(entity) {
        this.streamedInEntities.delete(entity.id);
    }

    updateWorker() {
        this.streamingWorker.postMessage({
            position: playerPosition.getPosition(),
            entities: this.entities,
            streamedIn: this.streamedInEntities
        })
    }
}