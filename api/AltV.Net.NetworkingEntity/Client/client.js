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
            this.onStreamIn(JSON.parse(entity));
        });
        webview.on("streamInBuffer", (entityBuffer) => {
            alt.log("client:" + JSON.stringify(entityBuffer));
            alt.log("onbuffer");
        });
        webview.on("networkingEntityStreamOut", (entity) => {
            this.onStreamOut(JSON.parse(entity));
        });
        webview.on("networkingEntityDataChange", (entity, newData) => {
            this.onDataChange(JSON.parse(entity), JSON.parse(newData));
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
                pos.x,
                pos.y,
                pos.z)
                //NetworkingEntityClient.roundDecimal(pos.x, 3),
                //NetworkingEntityClient.roundDecimal(pos.y, 3),
                //NetworkingEntityClient.roundDecimal(pos.z, 3));
        }, 100);
    }

    static roundDecimal(number, precision) {
        let factor = Math.pow(10, precision);
        return Math.round(number * factor) / factor;
    }
}

let networkingEntityClient = null;

export function create() {
    networkingEntityClient = new NetworkingEntityClient(new alt.WebView("http://resources/networking-entity/index.html"), true);
}

export function createWithWebView(webview) {
    networkingEntityClient = new NetworkingEntityClient(webview, true);
}

export function createNoneDefault() {
    networkingEntityClient = new NetworkingEntityClient(new alt.WebView("http://resources/networking-entity/index.html"), false);
}

export function createNoneDefaultWithWebView(webview) {
    if (!webview) {
        webview = new alt.WebView("http://resources/networking-entity/index.html");
    }
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

export default {
    create,
    createWithWebView,
    createNoneDefault,
    createNoneDefaultWithWebView,
    init,
    onStreamIn,
    onStreamOut,
    onDataChange
};