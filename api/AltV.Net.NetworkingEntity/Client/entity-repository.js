import playerPosition from "./player-position.js"
import proto from "./proto.js"
import streamingWorker from "./streaming-worker.mjs";

export default class EntityRepository {
    constructor(websocket) {
        this.websocket = websocket;
        // entity-id, entity
        this.entities = new Map();
        this.streamedInEntities = new Map();
        const workerBlob = new Blob([streamingWorker], {type: 'application/javascript'});
        this.streamingWorker = new Worker(window.URL.createObjectURL(workerBlob));
        playerPosition.update = (position) => {
            this.updateWorker();
        };
        this.streamingWorker.onmessage = event => {
            console.log(JSON.stringify(event.data));
            const streamIn = event.data.streamIn;
            const streamOut = event.data.streamOut;
            if (streamIn) {
                if (this.entities.has(streamIn.id)) {
                    this.streamedInEntities.set(streamIn.id, this.entities.get(streamIn.id));
                }
                proto.getProto().then((proto) => {
                    websocket.sendEvent({streamIn: proto.EntityStreamInEvent.create({entityId: streamIn.id})})
                });

                alt.emit("networkingEntityStreamIn", streamIn);
            } else if (streamOut) {
                this.streamedInEntities.delete(streamOut.id);
                proto.getProto().then((proto) => {
                    websocket.sendEvent({streamOut: proto.EntityStreamOutEvent.create({entityId: streamOut.id})})
                });
                alt.emit("networkingEntityStreamOut", streamOut);
            }
        };
    }

    isStreamedIn(id) {
        return this.streamedInEntities.has(id);
    }

    getEntities() {
        return this.entities.values();
    }

    setEntities(entities) {
        let newEntities = new Map();
        for (const entity of entities) {
            newEntities.set(entity.id, entity);
        }
        this.entities = newEntities;
        this.updateWorker();
    }

    addEntity(entity) {
        this.entities.set(entity.id, entity);
        this.streamingWorker.postMessage({
            position: playerPosition.getPosition(),
            entityToAdd: entity
        });
    }

    removeEntity(id) {
        if (!this.entities.has(id)) {
            return;
        }
        let entity = this.entities.get(id);
        if (!entity) return;
        this.entities.delete(id);
        this.streamingWorker.postMessage({
            position: playerPosition.getPosition(),
            entityToRemove: entity
        });
    }

    updateWorker() {
        this.streamingWorker.postMessage({
            position: playerPosition.getPosition(),
            entities: this.entities
        })
    }
}