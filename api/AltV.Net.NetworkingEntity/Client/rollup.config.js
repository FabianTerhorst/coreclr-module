import resolve from 'rollup-plugin-node-resolve';
import {string} from "rollup-plugin-string";

export default [{
    input: ['networking-entity.js'],
    output: {
        file: 'build/networking-entity.js',
        format: 'esm',
        sourcemap: true
    },
    cache: true,
    plugins: [
        resolve(),
        string({
            include: "**/*.mjs",
            exclude: []
        })
    ]
}];