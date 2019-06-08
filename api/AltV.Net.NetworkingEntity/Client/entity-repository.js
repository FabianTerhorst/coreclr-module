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
            console.log(event.data);
            const streamIn = event.data.streamIn;
            const streamOut = event.data.streamOut;
            if (streamIn) {
                this.addStreamedInEntity(streamIn);
                proto.getProto().then((proto) => {
                    websocket.sendEvent({streamIn: proto.EntityStreamInEvent.create({entityId: streamIn.id})})
                });

                alt.emit("networkingEntityStreamIn", streamIn);
            } else if (streamOut) {
                this.removeStreamedInEntity(streamOut);
                proto.getProto().then((proto) => {
                    websocket.sendEvent({streamOut: proto.EntityStreamOutEvent.create({entityId: streamOut.id})})
                });
                alt.emit("networkingEntityStreamOut", streamOut);
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