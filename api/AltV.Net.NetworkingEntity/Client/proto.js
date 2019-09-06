import proto from "./deps/protobuf.js";
import bundle from "./gen/bundle.json";

class Proto {
    constructor() {
        const root = proto.Root.fromJSON(bundle);
        this.Entity = root.lookupType("Entity.Entity");
        this.Position = root.lookupType("Entity.Position");
        this.ClientEvent = root.lookupType("Entity.ClientEvent");
        this.ServerEvent = root.lookupType("Entity.ServerEvent");
        this.AuthEvent = root.lookupType("Entity.AuthEvent");
        this.EntityStreamInEvent = root.lookupType("Entity.EntityStreamInEvent");
        this.EntityStreamOutEvent = root.lookupType("Entity.EntityStreamOutEvent");
    }
}

export default new Proto();