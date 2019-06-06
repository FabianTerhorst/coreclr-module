import entitiesRepository from "./entity-repository.mjs";
import proto from "./proto.mjs";

class WebSocket {
    constructor() {
        this.connection = new ReconnectingWebSocket('ws://localhost:46429');
        this.connection.binaryType = 'arraybuffer';
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

        this.connection.onmessage = async (e) => {
            const serverEvent = proto.getValue().ServerEvent.decode(new Uint8Array(await new Response(e.data).arrayBuffer()));
            const obj = proto.getValue().ServerEvent.toObject(serverEvent, {
                defaults: true
            });
            console.log('event', obj, serverEvent);
            if (obj.send != null) {
                const entities = obj.send.entities;

                entitiesRepository.setEntities(entities);
            }
        };
    }
}

export default new WebSocket();