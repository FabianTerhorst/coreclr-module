import WebSocket from "./websocket.mjs";

class NetworkingEntity {
    constructor() {
        try {
            alt.on("networkingEntitySetup", (url, token) => {
                new WebSocket(url, token);
            });
        } catch (e) {
            console.log(e);
            new WebSocket('ws://localhost:46429', '123');
        }
    }
}

export default new NetworkingEntity();
