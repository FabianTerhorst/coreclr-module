import resolve from 'rollup-plugin-node-resolve';
import {string} from "rollup-plugin-string";
import minify from 'rollup-plugin-babel-minify';
import json from 'rollup-plugin-json';
import copy from 'rollup-plugin-copy';

export default [{
    input: ['networking-entity.js'],
    output: {
        file: 'build/networking-entity.js',
        format: 'esm',
        sourcemap: false
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
        }),
        json({
            compact: true
        })
    ]
}, {
    input: ['client.js'],
    output: {
        file: 'build/client.js',
        format: 'esm',
        sourcemap: false
    },
    cache: true,
    plugins: [
        resolve(),
        minify({
            sourceMap: false
        }),
        json({
            compact: true
        }),
        copy({
            targets: [
                { src: 'index.html', dest: 'build' },
                { src: 'resource.cfg', dest: 'build' }
            ]
        })
    ]
}];