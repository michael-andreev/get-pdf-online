const webpack = require('webpack');
const merge = require('webpack-merge');
const helpers = require('./helpers');
const commonConfig = require('./webpack.app.js');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    // Configuration for server-side (prerendering) bundle suitable for running in Node
    return merge(commonConfig(env), {
        resolve: { mainFields: ['main'] },
        entry: {
            'main-server': helpers.root('ClientApp', 'boot-server.ts')
        },
        plugins: [
            new webpack.ContextReplacementPlugin(
                /@angular\b.*\b(bundles|linker)/,
                helpers.root('ClientApp')
            ) // Workaround for https://github.com/angular/angular/issues/11580
            /*new webpack.DllReferencePlugin({
                context: helpers.root(),
                manifest: require(helpers.root('ClientApp', 'dist', 'vendor-manifest.json')),
                sourceType: 'commonjs2',
                name: './vendor'
            })*/
        ],
        output: {
            libraryTarget: 'commonjs',
            path: helpers.root('ClientApp', 'dist')
        },
        target: 'node',
        devtool: 'inline-source-map'
    });
};
