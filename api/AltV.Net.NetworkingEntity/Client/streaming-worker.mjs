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
    if (!this.dimension) {
        this.dimension = 0;
    }
    //if (!this.entityAreas) {
    //    this.entityAreas = new Map();
    //}
    if (!this.streamedIn) {
        this.streamedIn = new Map();
    }
    if (!this.newStreamIn) {
        this.newStreamIn = new Set();
    }
    if (!this.newStreamOut) {
        this.newStreamOut = new Set();
    }

    if (data.reset) {
        this.streamedIn.clear();
        this.newStreamIn.clear();
        this.newStreamOut.clear();
    }

    if (data.position) {
        this.position = data.position;
    }
    if (data.dimension) {
        this.dimension = data.dimension;
    }
    if (data.entities) {
        // Fill entities in areas
        for (let i = 0; i < maxAreaIndex; i++) {
            for (let j = 0; j < maxAreaIndex; j++) {
                this.areas[i][j] = [];
            }
        }
        for (const entity of data.entities) {
            addEntityToArea(entity);
        }
    }
    if (data.entityToAdd) {
        addEntityToArea(data.entityToAdd);
    }
    if (data.entityToRemove) {
        if (this.streamedIn.has(data.entityToRemove.id)) {
            this.streamedIn.delete(data.entityToRemove.id);
            postMessage({streamOut: [data.entityToRemove.id]});
        }
        removeEntityFromArea(data.entityToRemove);
    }
    if (this.position) {
        start(this.position);
    }
};

function addEntityToArea(entity) {
    const [startingYIndex, startingXIndex, stoppingYIndex, stoppingXIndex] = calcStartStopIndex(entity);
    if (startingYIndex == null || startingXIndex == null || stoppingYIndex == null || stoppingXIndex == null) return;
    for (let i = startingYIndex; i <= stoppingYIndex; i++) {
        for (let j = startingXIndex; j <= stoppingXIndex; j++) {
            this.areas[j][i].push(entity);
            /*let entityAreasArr;
            if (!this.entityAreas.has(entity.id)) {
                entityAreasArr = [];
                this.entityAreas.set(entity.id, entityAreasArr);
            } else {
                entityAreasArr = this.entityAreas.get(entity.id);
            }
            entityAreasArr.push([this.areas[j][i], this.areas[j][i].length - 1]);*/
        }
    }
}

function calcStartStopIndex(entity) {
    let posX = offsetPosition(entity.position.x);
    let posY = offsetPosition(entity.position.y);

    if (posX < 0 || posY < 0 || posX > maxCoordinate || posY > maxCoordinate) return [null, null, null, null];

    let maxX = posX + entity.range;
    let maxY = posY + entity.range;
    let minX = posX - entity.range;
    let minY = posY - entity.range;

    let startingYIndex = Math.floor(minY / areaSize);
    let startingXIndex = Math.floor(minX / areaSize);
    let stoppingYIndex = Math.floor(maxY / areaSize);
    let stoppingXIndex = Math.floor(maxX / areaSize);

    return [startingYIndex, startingXIndex, stoppingYIndex, stoppingXIndex];
}

function removeEntityFromArea(entity) {
    /*if (this.entityAreas.has(entity.id)) {
        for (const [areaArr, index] of this.entityAreas.get(entity.id)) {
            areaArr.splice(index, 1);
            console.log("index to remove", index);
            console.log("new arr", areaArr);
            // Finds entities stored behind that and decrement the stored indexes by one
            for (let i = index; i < areaArr.length; i++) {
                if (this.entityAreas.has(areaArr[i].id)) {
                    const [entityAreaArr, entityIndex] = this.entityAreas.get(areaArr[i].id);
                    console.log("index to update", entityIndex);
                    this.entityAreas.set(areaArr[i].id, [entityAreaArr, entityIndex - 1]);
                }
            }
        }
    }*/
    const [startingYIndex, startingXIndex, stoppingYIndex, stoppingXIndex] = calcStartStopIndex(entity);
    if (startingYIndex == null || startingXIndex == null || stoppingYIndex == null || stoppingXIndex == null) return;
    for (let i = startingYIndex; i <= stoppingYIndex; i++) {
        for (let j = startingXIndex; j <= stoppingXIndex; j++) {
            this.areas[j][i] = this.areas[j][i].filter((arrEntity) => arrEntity.id !== entity.id);
        }
    }
}

function distance(v1, v2) {
    const dx = v1.x - v2.x;
    const dy = v1.y - v2.y;
    const dz = v1.z - v2.z;

    return Math.sqrt(dx * dx + dy * dy + dz * dz);
}

function offsetPosition(value) {
    return value + 10000;
}

function start(position) {
    for (const [id, entity] of this.streamedIn) {
        if (distance(entity.position, position) > entity.range || !canSeeOtherDimension(this.dimension, entity.dimension)) {
            this.newStreamOut.add(entity.id);
        }
    }

    for (let key of this.newStreamOut) {
        this.streamedIn.delete(key);
    }

    if (this.newStreamOut.size > 0) {
        postMessage({streamOut: [...this.newStreamOut]});
        this.newStreamOut.clear();
    }

    let posX = offsetPosition(position.x);
    let posY = offsetPosition(position.y);

    if (posX < 0 || posY < 0 || posX > maxCoordinate || posY > maxCoordinate) return;

    let xIndex = Math.floor(posX / areaSize);
    let yIndex = Math.floor(posY / areaSize);

    let entitiesInArea = this.areas[xIndex][yIndex];

    for (let entity of entitiesInArea) {
        if (!this.streamedIn.has(entity.id)) {
            if (canSeeOtherDimension(this.dimension, entity.dimension) && distance(entity.position, position) <= entity.range) {
                this.newStreamIn.add(entity.id);
                this.streamedIn.set(entity.id, entity)
            }
        }
    }

    if (this.newStreamIn.size > 0) {
        postMessage({streamIn: [...this.newStreamIn]});
        this.newStreamIn.clear();
    }
}

/*
X can see only X
-X can see 0 and -X
0 can't see -X and X
 */
function canSeeOtherDimension(dimension, otherDimension) {
    if (dimension > 0) return dimension === otherDimension;
    if (dimension < 0) return otherDimension === 0 || dimension === otherDimension;
    if (dimension === 0) return otherDimension === 0;
    return false;
}