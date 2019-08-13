import { log, onServer, offServer, Player, WebView, clearInterval, setInterval } from 'alt';

// This is the client class to communicate with the webview
// e.g. const client = new NetworkingEntityClient(webview);

class NetworkingEntityClient {
    // create position submit interval
    constructor(webview, defaultToken, defaultWebView) {
        this.webview = webview;
        this.defaultToken = defaultToken;
        this.defaultWebView = defaultWebView;
        this.streamedInEntities = {};
        this.onStreamIn = () => {
        };
        this.onStreamOut = () => {
        };
        this.onDataChange = () => {
        };
        webview.on("streamIn", (entities) => {
            for (const entity of JSON.parse(entities)) {
                this.streamedInEntities[entity.id] = entity;
                this.onStreamIn(entity);
            }
        });
        webview.on("streamInBuffer", (entityBuffer) => {
            log("client:" + JSON.stringify(entityBuffer));
            log("onbuffer");
        });
        webview.on("streamOut", (entities) => {
            for (const entity of JSON.parse(entities)) {
                const currEntity = this.streamedInEntities[entity.id];
                if (currEntity) {
                    this.onStreamOut(currEntity);
                    delete this.streamedInEntities[entity.id];
                } else {
                    this.onStreamOut(entity);
                }
            }
        });
        webview.on("dataChange", (entityAndNewData) => {
            const entityAndNewDataParsed = JSON.parse(entityAndNewData);
            const currEntity = this.streamedInEntities[entityAndNewDataParsed.entity.id];
            if (currEntity) {
                currEntity.data = entityAndNewDataParsed.entity.data;
                this.onDataChange(currEntity, entityAndNewDataParsed.data);
            } else {
                this.onDataChange(entityAndNewDataParsed.entity, entityAndNewDataParsed.data);
            }
        });
        if (defaultToken) {
            this.tokenCallback = (url, token) => {
                this.init(url, token);
            };
            onServer("streamingToken", this.tokenCallback);
        }
    }

    init(url, token) {
        this.webview.emit("entitySetup", url, token);
        const localPlayer = Player.local;
        let pos;
        this.interval = setInterval(() => {
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
        clearInterval(this.interval);
        if (this.defaultToken) {
            offServer("streamingToken", this.tokenCallback);
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
    return new WebView("http://resources/networking-entity/index.html");
}

export function init(url, token) {
    if (networkingEntityClient == null) {
        log("call create(webview) first");
        return;
    }
    networkingEntityClient.init(url, token)
}

export function destroy() {
    if (networkingEntityClient == null) {
        log("call create(webview) first");
        return;
    }
    networkingEntityClient.destroy()
}

export function onStreamIn(callback) {
    if (networkingEntityClient == null) {
        log("call create(webview) first");
        return;
    }
    networkingEntityClient.onStreamIn = (entity) => {
        callback(entity);
    };
}

export function onStreamOut(callback) {
    if (networkingEntityClient == null) {
        log("call create(webview) first");
        return;
    }
    networkingEntityClient.onStreamOut = (entity) => {
        callback(entity);
    };
}

export function onDataChange(callback) {
    if (networkingEntityClient == null) {
        log("call create(webview) first");
        return;
    }
    networkingEntityClient.onDataChange = (entity, newData) => {
        callback(entity, newData);
    };
}

export function getStreamedInEntities() {
    return networkingEntityClient.streamedInEntities;
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
    onDataChange,
    getStreamedInEntities
};