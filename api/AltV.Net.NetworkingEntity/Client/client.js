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
        webview.on("networkingEntityStreamIn", (entities) => {
            for (const entity of entities) {
                this.onStreamIn(entity);
            }
        });
        webview.on("networkingEntityStreamOut", (entities) => {
            for (const entity of entities) {
                this.onStreamOut(entity);
            }
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
            this.webview.emit("playerPosition",
                NetworkingEntityClient.roundDecimal(pos.x, 3),
                NetworkingEntityClient.roundDecimal(pos.y, 3),
                NetworkingEntityClient.roundDecimal(pos.z, 3));
        }, 100);
    }

    static roundDecimal(number, precision) {
        let factor = Math.pow(10, precision);
        return Math.round(number * factor) / factor;
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