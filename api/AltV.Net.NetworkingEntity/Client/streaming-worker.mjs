onmessage = function (e) {
    let data = e.data;
    if (data.position) {
        this.position = data.position;
    }
    if (data.entities) {
        this.entities = data.entities;
    }
    if (data.streamedIn) {
        this.streamedIn = data.streamedIn;
    }
    console.log("execute worker", this.position, this.entities, this.streamedIn);
    start(this.position, this.entities, this.streamedIn);
};

function distance(v1, v2) {
    const dx = v1.x - v2.x;
    const dy = v1.y - v2.y;
    const dz = v1.z - v2.z;

    return Math.sqrt(dx * dx + dy * dy + dz * dz);
}

function start(position, entities, streamedIn) {
    for (const [id, entity] of entities) {
        if (!streamedIn.has(id)) {
            if (distance(entity.position, position) <= entity.range) {
                postMessage({streamIn: entity});
            }
        }
    }
    for (const [_, entity] of streamedIn) {
        if (distance(entity.position, position) > entity.range) {
            postMessage({streamOut: entity});
        }
    }
}