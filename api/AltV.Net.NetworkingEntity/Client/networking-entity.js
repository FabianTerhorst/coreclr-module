const connection = new ReconnectingWebSocket('ws://localhost:46429');
connection.binaryType = 'arraybuffer';

// List of promises waiting for protoBuf to finish indexing
const protoBufGets = [];

let proto = null;

protobuf.load("entity.proto", function (err, root) {
    if (err)
        throw err;
    proto = {
        clientEvent: root.lookupType("Entity.ClientEvent"),
        serverEvent: root.lookupType("Entity.ServerEvent"),
        authEvent: root.lookupType("Entity.AuthEvent")
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
        const authEvent = proto.authEvent.create({token: "123"});
        const clientEvent = proto.clientEvent.create({auth: authEvent});
        const buffer = proto.clientEvent.encode(clientEvent).finish();
        connection.send(buffer);
    });
};

connection.onerror = function (error) {
    console.log("err", error);
};

connection.onmessage = async function (e) {
    console.log('event', proto.serverEvent.decode(new Uint8Array(await new Response(e.data).arrayBuffer())));
};
