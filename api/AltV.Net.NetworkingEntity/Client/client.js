import alt from 'alt';

// This is the client class to communicate with the webview
// e.g. const client = new NetworkingEntityClient(webview);
export default class NetworkingEntityClient {
    // create position submit interval
    constructor(webview, defaultToken = true) {
        this.webview = webview;
        this.onStreamIn = () => {
        };
        this.onStreamOut = () => {
        };
        this.onDataChange = () => {
        };
        webview.on("networkingEntityStreamIn", (entity) => {
            this.onStreamIn(entity);
        });
        webview.on("networkingEntityStreamOut", (entity) => {
            this.onStreamOut(entity);
        });
        webview.on("networkingEntityDataChange", (entity, newData) => {
            this.onDataChange(entity, newData);
        });
        if (defaultToken) {
            alt.onServer("streamingToken", (url, token) => {
                this.init(url, token);
            });
        }
    }

    init(url, token) {
        this.webview.emit("networkingEntitySetup", url, token);
        const localPlayer = alt.getLocalPlayer();
        let pos;
        alt.setInterval(() => {
            pos = localPlayer.pos;
            webview.emit("playerPosition", pos.x, pos.y, pos.z);
        }, 100);
    }
}