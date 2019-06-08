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
    start(this.position, this.entities, this.streamedIn);
};

function distance(v1, v2) {
    const dx = v1.x - v2.x;
    const dy = v1.y - v2.y;
    const dz = v1.z - v2.z;

    return Math.sqrt(dx * dx + dy * dy + dz * dz);
}

function start(position, entities, streamedIn) {
    console.log(entities);
    for (const [id, entity] of entities) {
        if (!streamedIn.has(id)) {
            if (distance(entity.position, position) <= entity.range) {
                postMessage({streamIn: entity});
                streamedIn.set(id, entity)
            }
        }
    }
    for (const [id, entity] of streamedIn) {
        if (distance(entity.position, position) > entity.range) {
            postMessage({streamOut: entity});
            streamedIn.delete(id);
        }
    }
}