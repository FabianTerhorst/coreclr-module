import alt from 'alt';

// This is the client class to communicate with the webview
// e.g. const client = new NetworkingEntityClient(webview);
class NetworkingEntityClient {
    // create position submit interval
    constructor(webview, defaultToken, defaultWebView) {
        this.webview = webview;
        this.defaultToken = defaultToken;
        this.defaultWebView = defaultWebView;
        this.onStreamIn = () => {
        };
        this.onStreamOut = () => {
        };
        this.onDataChange = () => {
        };
        webview.on("streamIn", (entities) => {
            for (const entity of JSON.parse(entities)) {
                this.onStreamIn(entity);
            }
        });
        webview.on("streamInBuffer", (entityBuffer) => {
            alt.log("client:" + JSON.stringify(entityBuffer));
            alt.log("onbuffer");
        });
        webview.on("streamOut", (entities) => {
            for (const entity of JSON.parse(entities)) {
                this.onStreamOut(entity);
            }
        });
        webview.on("dataChange", (entityAndNewData) => {
            const entityAndNewDataParsed = JSON.parse(entityAndNewData);
            this.onDataChange(entityAndNewDataParsed.entity, entityAndNewDataParsed.data);
        });
        if (defaultToken) {
            this.tokenCallback = (url, token) => {
                this.init(url, token);
            };
            alt.onServer("streamingToken", this.tokenCallback);
        }
    }

    init(url, token) {
        this.webview.emit("entitySetup", url, token);
        const localPlayer = alt.getLocalPlayer();
        let pos;
        this.interval = alt.setInterval(() => {
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

    destroy() {
        this.webview.emit("entityDestroy");
        alt.clearInterval(this.interval);
        if (this.defaultToken) {
            alt.offServer("streamingToken", this.tokenCallback);
        }
    }

    static roundDecimal(number, precision) {
        let factor = Math.pow(10, precision);
        return Math.round(number * factor) / factor;
    }
}

let networkingEntityClient = null;

export function create() {
    networkingEntityClient = new NetworkingEntityClient(createWebView(), true, true);
}

export function createWithWebView(webview) {
    networkingEntityClient = new NetworkingEntityClient(webview, true, false);
}

export function createNoneDefault() {
    networkingEntityClient = new NetworkingEntityClient(createWebView(), false, true);
}

export function createNoneDefaultWithWebView(webview) {
    networkingEntityClient = new NetworkingEntityClient(webview, false, false);
}

export function createWebView() {
    return new alt.WebView("http://resources/networking-entity/index.html");
}

export function init(url, token) {
    if (networkingEntityClient == null) {
        alt.log("call create(webview) first");
        return;
    }
    networkingEntityClient.init(url, token)
}

export function destroy() {
    if (networkingEntityClient == null) {
        alt.log("call create(webview) first");
        return;
    }
    networkingEntityClient.destroy()
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
    createWebView,
    createWithWebView,
    createNoneDefault,
    createNoneDefaultWithWebView,
    init,
    destroy,
    onStreamIn,
    onStreamOut,
    onDataChange
};