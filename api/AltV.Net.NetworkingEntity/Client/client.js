import alt from 'alt';

// This is the client class to communicate with the webview
// e.g. const client = new NetworkingEntityClient(webview);
class NetworkingEntityClient {
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
            this.webview.emit("playerPosition", pos.x, pos.y, pos.z);
        }, 100);
    }
}

let networkingEntityClient = null;

export function create(webview) {
    networkingEntityClient = new NetworkingEntityClient(webview, true);
}

export function createNoneDefault(webview) {
    networkingEntityClient = new NetworkingEntityClient(webview, false);
}

export function init(url, token) {
    if (networkingEntityClient == null) {
        alt.log("call create(webview) first");
        return;
    }
    networkingEntityClient.init(url, token)
}

export function onStreamIn(callback) {
    if (networkingEntityClient == null) {
        alt.log("call create(webview) first");
        return;
    }
    networkingEntityClient.onStreamIn = (entity) => {
        callback(entity);
    };
}

export function onStreamOut(callback) {
    if (networkingEntityClient == null) {
        alt.log("call create(webview) first");
        return;
    }
    networkingEntityClient.onStreamOut = (entity) => {
        callback(entity);
    };
}

export function onDataChange(callback) {
    if (networkingEntityClient == null) {
        alt.log("call create(webview) first");
        return;
    }
    networkingEntityClient.onDataChange = (entity, newData) => {
        callback(entity, newData);
    };
}

export default {create, createNoneDefault, init, onStreamIn, onStreamOut, onDataChange};