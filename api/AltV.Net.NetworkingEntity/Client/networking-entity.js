const connection = new ReconnectingWebSocket('ws://localhost:46429');
connection.binaryType = 'arraybuffer';

// List of promises waiting for protoBuf to finish indexing
const protoBufGets = [];

let proto = null;

protobuf.load("entity.proto", function (err, root) {
    if (err)
        throw err;
    proto = {
        Position: root.lookupType("Entity.Position"),
        ClientEvent: root.lookupType("Entity.ClientEvent"),
        ServerEvent: root.lookupType("Entity.ServerEvent"),
        AuthEvent: root.lookupType("Entity.AuthEvent"),
        EntityStreamInEvent: root.lookupType("Entity.EntityStreamInEvent"),
        EntityStreamOutEvent: root.lookupType("Entity.EntityStreamOutEvent")
    };
    for (const get of protoBufGets) {
        get(proto);
    }
});

function getProto() {
    return new Promise((resolve, reject) => {
        if (proto != null) {
            resolve(proto);
        } else {
            protoBufGets.push(resolve);
        }
    });
}

connection.onopen = function () {
    getProto().then((proto) => {
        const authEvent = proto.AuthEvent.create({token: "123"});
        const clientEvent = proto.ClientEvent.create({auth: authEvent});
        const buffer = proto.ClientEvent.encode(clientEvent).finish();
        connection.send(buffer);
    });
};

connection.onerror = function (error) {
    console.log("err", error);
};

connection.onmessage = async function (e) {
    console.log('event', proto.ServerEvent.decode(new Uint8Array(await new Response(e.data).arrayBuffer())));
};
