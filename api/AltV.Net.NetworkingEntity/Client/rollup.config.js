import resolve from 'rollup-plugin-node-resolve';
import {string} from "rollup-plugin-string";
import minify from 'rollup-plugin-babel-minify';

export default [{
    input: ['networking-entity.js'],
    output: {
        file: 'build/networking-entity.js',
        format: 'esm',
        sourcemap: false
    },
    moduleContext: (id) => {
        const path = id.split("/");
        if (path.length > 0 && path[path.length - 1] === "reconnecting-websocket.min.js") {
            return "window";
        }
        return undefined;
    },
    cache: true,
    plugins: [
        resolve(),
        string({
            include: "**/*.mjs",
            exclude: []
        }),
        minify({
            sourceMap: false
        })
    ]
}];