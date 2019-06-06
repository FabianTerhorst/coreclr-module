class Proto {

    constructor() {
        // List of promises waiting for protoBuf to finish indexing
        this.protoBufGets = [];
        this.proto = null;

        protobuf.load("entity.proto", (err, root) => {
            if (err)
                throw err;
            this.proto = {
                Position: root.lookupType("Entity.Position"),
                Entity: root.lookupType("Entity.Entity"),
                ClientEvent: root.lookupType("Entity.ClientEvent"),
                ServerEvent: root.lookupType("Entity.ServerEvent"),
                AuthEvent: root.lookupType("Entity.AuthEvent"),
                EntityStreamInEvent: root.lookupType("Entity.EntityStreamInEvent"),
                EntityStreamOutEvent: root.lookupType("Entity.EntityStreamOutEvent")
            };
            for (const get of this.protoBufGets) {
                get(this.proto);
            }
        });

        this.executor = this.executor.bind(this);
        this.getProto = this.getProto.bind(this);
        this.getValue = this.getValue.bind(this);
    }

    getProto() {
        return new Promise(this.executor);
    }

    getValue() {
        return this.proto;
    }

    executor(resolve, reject) {
        if (this.proto != null) {
            resolve(this.proto);
        } else {
            this.protoBufGets.push(resolve);
        }
    }
}

export default new Proto();