import WebSocket from "./websocket.mjs";

export default class NetworkingEntity {
    constructor(url, token) {
        new WebSocket(url, token);
    }
}
