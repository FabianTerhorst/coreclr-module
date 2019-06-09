import WebSocket from "./websocket.js";
import "./deps/reconnecting-websocket.min.js";

class NetworkingEntity {
    constructor() {
        alt.on("networkingEntitySetup", (url, token) => {
            new WebSocket(url, token);
        });
    }
}

export default new NetworkingEntity();
