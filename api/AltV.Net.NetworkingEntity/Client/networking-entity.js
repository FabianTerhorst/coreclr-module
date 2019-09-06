import WebSocket from "./websocket.js";
import "./deps/reconnecting-websocket.min.js";

class NetworkingEntity {
    constructor() {
        alt.on("entitySetup", (url, token) => {
            const protocolSplit = url.split("//");
            if (protocolSplit.length < 2) {
                console.log("Invalid websocket protocol:" +  url);
                return;
            }
            const protocol = protocolSplit[0] + "//";
            const splitUrl = protocolSplit[1].split(":");
            if (splitUrl.length > 2) {
                let address = "";
                for (let i = 0; i < splitUrl.length - 1; i++) {
                    address += splitUrl[i];
                    if (i < splitUrl.length - 2) {
                        address += ":";
                    }
                }
                this.websocket = new WebSocket(protocol + "[" + address + "]:" + splitUrl[splitUrl.length - 1], token);
            } else {
                this.websocket = new WebSocket(url, token);
            }
        });

        alt.on("entityDestroy", () => {
            if (this.websocket) {
                this.websocket.deinit();
            }
        });
    }
}

export default new NetworkingEntity();
