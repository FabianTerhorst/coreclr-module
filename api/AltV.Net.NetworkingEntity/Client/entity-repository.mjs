import playerPosition from "./player-position.mjs"

class EntityRepository {
    constructor() {
        // entity-id, entity
        this.entities = new Map();
        this.streamedInEntities = new Map();
        this.streamingWorker = new Worker('streaming-worker.mjs');
        playerPosition.update = (position) => {
            this.updateWorker();
        };
        this.streamingWorker.onmessage = event => {
            if (event.streamIn) {
                this.addStreamedInEntity(event.streamIn);
                //TODO: send event to server
            } else if (event.streamOut) {
                this.removeStreamedInEntity(event.streamOut);
                //TODO: send event to server
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
        this.updateWorker();
    }

    removeStreamedInEntity(entity) {
        this.streamedInEntities.delete(entity.id);
        this.updateWorker();
    }

    updateWorker() {
        this.streamingWorker.postMessage({
            position: playerPosition.getPosition(),
            entities: this.entities,
            streamedIn: this.streamedInEntities
        })
    }
}

export default new EntityRepository();