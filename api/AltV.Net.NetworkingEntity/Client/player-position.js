class PlayerPosition {
    constructor() {
        this.position = {x: 0, y: 0, z: 0};
        this.overridePosition = null;
        this.update = null;
        alt.on("playerPosition", (x, y, z) => {
            this.position.x = x;
            this.position.y = y;
            this.position.z = z;
            if (this.update && this.overridePosition == null) {
                this.update(this.position);
            }
        });
        alt.on("overridePlayerPosition", (x, y, z) => {
          this.setOverridePosition({x: x, y: y, z: z});
        });
        alt.on("stopOverridePlayerPosition", () => {
            this.setOverridePosition(null);
        });
    }

    getPosition() {
        if (this.overridePosition) {
            return this.overridePosition;
        }
        return this.position;
    }

    setOverridePosition(position) {
        this.overridePosition = position;
        if (this.update) {
            if (this.overridePosition) {
                this.update(this.overridePosition);
            } else if (this.position) {
                this.update(this.position);
            }
        }
    }
}

export default new PlayerPosition();