const webpack = require('webpack');
const merge = require('webpack-merge');
// const { AotPlugin } = require('@ngtools/webpack');
const helpers = require('./helpers');
const commonConfig = require('./webpack.app.js');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    // Configuration for server-side (prerendering) bundle suitable for running in Node
    return merge(commonConfig(env), {
        resolve: { mainFields: ['main'] },
        // entry: { 'main-server': helpers.root('ClientApp', 'boot-server.ts') },
        plugins: [
            new webpack.DllReferencePlugin({
                context: helpers.root(),
                manifest: require(helpers.root('ClientApp', 'dist', 'vendor-manifest.json')),
                sourceType: 'commonjs2',
                name: './vendor'
            }) /*,
            new AotPlugin({
                mainPath: helpers.root('ClientApp', 'boot-server.ts'),
                entryModule: helpers.root('ClientApp', 'app', 'app.module.server#AppModuleServer'),
                tsConfigPath: './tsconfig.json',
                skipCodeGeneration: true
            })*/
        ].concat(isDevBuild ? [] : []),
        output: {
            libraryTarget: 'commonjs',
            path: helpers.root('ClientApp', 'dist')
        },
        target: 'node',
        devtool: 'inline-source-map'
    });
};
