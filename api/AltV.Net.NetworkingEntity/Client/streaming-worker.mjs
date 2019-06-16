let maxCoordinate = 50000;
let areaSize = 100;
let maxAreaIndex = maxCoordinate / areaSize;

onmessage = function (e) {
    let data = e.data;
    if (!this.areas) { // Init areas for fast spacing algorithm
        this.areas = new Array(maxAreaIndex);
        for (let i = 0; i < maxAreaIndex; i++) {
            this.areas[i] = new Array(maxAreaIndex);
            for (let j = 0; j < maxAreaIndex; j++) {
                this.areas[i][j] = [];
            }
        }
    }
    if (data.position) {
        this.position = data.position;
    }
    if (data.entities) {
        // Fill entities in areas
        for (const [id, entity] of data.entities) {
            let posX = offsetPosition(entity.position.x);
            let posY = offsetPosition(entity.position.y);

            if (posX < 0 || posY < 0 || posX > maxCoordinate || posY > maxCoordinate) continue;

            let maxX = posX + entity.range;
            let maxY = posY + entity.range;
            let minX = posX - entity.range;
            let minY = posY - entity.range;

            let startingYIndex = Math.floor(minY / areaSize);
            let startingXIndex = Math.floor(minX / areaSize);
            let stoppingYIndex = Math.floor(maxY / areaSize);
            let stoppingXIndex = Math.floor(maxX / areaSize);

            for (let i = startingYIndex; i <= stoppingYIndex; i++) {
                for (let j = startingXIndex; j <= stoppingXIndex; j++) {
                    this.areas[i][j].push(entity);
                }
            }
        }
        this.entities = data.entities;
    }
    if (data.streamedIn) {
        this.streamedIn = data.streamedIn;
    }
    start(this.position, this.entities, this.streamedIn);
};

function distance(v1, v2) {
    const dx = v1.x - v2.x;
    const dy = v1.y - v2.y;
    const dz = v1.z - v2.z;

    return Math.sqrt(dx * dx + dy * dy + dz * dz);
}

function offsetPosition(value) {
    return value + 10000;
}

function start(position, entities, streamedIn) {
    let posX = offsetPosition(position.x);
    let posY = offsetPosition(position.y);

    if (posX < 0 || posY < 0 || posX > maxCoordinate || posY > maxCoordinate) return;

    let xIndex = Math.floor(posX / areaSize);
    let yIndex = Math.floor(posY / areaSize);

    let entitiesInArea = this.areas[xIndex][yIndex];

    for (let entity of entitiesInArea) {
        if (!streamedIn.has(id)) {
            if (distance(entity.position, position) <= entity.range) {
                postMessage({streamIn: entity});
                streamedIn.set(id, entity)
            }
        }
    }
    /*for (const [id, entity] of entities) {
        if (!streamedIn.has(id)) {
            if (distance(entity.position, position) <= entity.range) {
                postMessage({streamIn: entity});
                streamedIn.set(id, entity)
            }
        }
    }*/
    for (const [id, entity] of streamedIn) {
        if (distance(entity.position, position) > entity.range) {
            postMessage({streamOut: entity});
            streamedIn.delete(id);
        }
    }
}