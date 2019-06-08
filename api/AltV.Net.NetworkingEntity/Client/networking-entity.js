import WebSocket from "./websocket.js";

class NetworkingEntity {
    constructor() {
        alt.on("networkingEntitySetup", (url, token) => {
            new WebSocket(url, token);
        });
    }
}

export default new NetworkingEntity();
