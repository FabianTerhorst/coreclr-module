import EntityRepository from "./entity-repository.mjs";
import proto from "./proto.mjs";

class WebSocket {
    constructor() {
        this.connection = new ReconnectingWebSocket('ws://localhost:46429');
        this.connection.binaryType = 'arraybuffer';

        this.entityRepository = new EntityRepository(this);

        this.connection.onopen = () => {
            proto.getProto().then((proto) => {
                const authEvent = proto.AuthEvent.create({token: "123"});
                const clientEvent = proto.ClientEvent.create({auth: authEvent});
                const buffer = proto.ClientEvent.encode(clientEvent).finish();
                this.connection.send(buffer);
            });
        };

        this.connection.onerror = (error) => {
            console.log("err", error);
        };

        this.connection.onmessage = (e) => {
            proto.getProto().then(async (proto) => {
                const serverEvent = proto.ServerEvent.decode(new Uint8Array(await new Response(e.data).arrayBuffer()));
                const obj = proto.ServerEvent.toObject(serverEvent, {
                    defaults: true
                });
                console.log('event', obj, serverEvent);
                if (obj.send != null) {
                    const entities = obj.send.entities;
                    this.entityRepository.setEntities(entities);
                }
            });
        };
    }

    sendEvent(event) {
        proto.getProto().then((proto) => {
            const clientEvent = proto.ClientEvent.create(event);
            const buffer = proto.ClientEvent.encode(clientEvent).finish();
            this.connection.send(buffer);
        })
    }
}

export default new WebSocket();