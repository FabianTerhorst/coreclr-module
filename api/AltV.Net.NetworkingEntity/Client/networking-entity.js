import WebSocket from "./websocket.js";
import "./deps/reconnecting-websocket.min.js";

class NetworkingEntity {
    constructor() {
        alt.on("entitySetup", (url, token) => {
            this.websocket = new WebSocket(url, token);
        });

        alt.on("entityDestroy", () => {
            if (this.websocket) {
                this.websocket.deinit();
            }
        });
    }
}

export default new NetworkingEntity();
