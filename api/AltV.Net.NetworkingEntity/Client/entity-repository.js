import playerPosition from "./player-position.js"
import proto from "./proto.js"
import streamingWorker from "./streaming-worker.mjs";
import clientRepository from "./client-repository.js";

export default class EntityRepository {
    constructor(websocket) {
        this.websocket = websocket;
        // entity-id, entity
        this.entities = new Map();
        this.streamedInEntities = new Map();
        const workerBlob = new Blob([streamingWorker], {type: 'application/javascript'});
        this.streamingWorker = new Worker(window.URL.createObjectURL(workerBlob));
        playerPosition.update = (position) => {
            this.streamingWorker.postMessage({
                position: position
            });
        };
        this.streamingWorker.onmessage = event => {
            const streamIns = event.data.streamIn;
            const streamOuts = event.data.streamOut;
            if (streamIns !== undefined) {
                const entities = [];
                for (const streamIn of streamIns) {
                    if (!this.entities.has(streamIn)) {
                        console.log("entity " + streamIn + " not found");
                        continue;
                    }
                    const entity = this.entities.get(streamIn);
                    this.streamedInEntities.set(streamIn, entity);
                    websocket.sendEvent({streamIn: proto.EntityStreamInEvent.create({entityId: streamIn})});
                    entities.push(entity);
                }
                if (entities.length > 0) {
                    alt.emit("streamIn", JSON.stringify(entities));
                }
            }
            if (streamOuts !== undefined) {
                const entities = [];
                for (const streamOut of streamOuts) {
                    websocket.sendEvent({streamOut: proto.EntityStreamOutEvent.create({entityId: streamOut})});
                    if (!this.streamedInEntities.has(streamOut)) {
                        console.log("entity " + streamOut + " not found");
                        continue;
                    }
                    const entity = this.streamedInEntities.get(streamOut);
                    entities.push(entity);
                    this.streamedInEntities.delete(streamOut);
                }
                if (entities.length > 0) {
                    alt.emit("streamOut", JSON.stringify(entities));
                }
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
            entityToAdd: EntityRepository.copyEntityWithoutData(entity)
        });
    }

    static copyEntityWithoutData(entity) {
        return {
            id: entity.id,
            range: entity.range,
            dimension: entity.dimension,
            position: {
                x: EntityRepository.roundDecimal(entity.position.x, 3),
                y: EntityRepository.roundDecimal(entity.position.y, 3),
                z: EntityRepository.roundDecimal(entity.position.z, 3)
            }
        };
    }

    static roundDecimal(number, precision) {
        let factor = Math.pow(10, precision);
        return Math.round(number * factor) / factor;
    }

    copyEntitiesWithoutData() {
        let copiedEntities = [];
        for (const [_, entity] of this.entities) {
            copiedEntities.push(EntityRepository.copyEntityWithoutData(entity));
        }
        return copiedEntities;
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
            entityToRemove: EntityRepository.copyEntityWithoutData(entity)
        });
    }

    updateWorker() {
        this.streamingWorker.postMessage({
            position: playerPosition.getPosition(),
            dimension: clientRepository.dimension,
            entities: this.copyEntitiesWithoutData()
        });
    }

    resetWorker() {
        this.streamingWorker.postMessage({
            reset: true
        });
    }
}