const webpack = require('webpack');
const merge = require('webpack-merge');
const BabiliPlugin = require("babili-webpack-plugin");
const helpers = require('./helpers');
const commonConfig = require('./webpack.app.js');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    // Configuration for server-side (prerendering) bundle suitable for running in Node
    return merge(commonConfig(env), {
        // resolve: { mainFields: ['main'] },
        plugins: [
            /*new webpack.ContextReplacementPlugin(
                /@angular\b.*\b(bundles|linker)/,
                helpers.root('ClientApp')
            ),*/ // Workaround for https://github.com/angular/angular/issues/11580
            /*new webpack.DllReferencePlugin({
                context: helpers.root(),
                manifest: require(helpers.root('ClientApp', 'dist', 'vendor-manifest.json')),
                sourceType: 'commonjs2',
                name: './vendor'
            })*/
        ].concat(isDevBuild ? [
            // Plugins that apply in development builds only
        ] : [
                // Plugins that apply in production builds only
                // new webpack.optimize.UglifyJsPlugin()
                new BabiliPlugin()
            ]),
        output: {
            libraryTarget: 'commonjs',
            path: helpers.root('ClientApp', 'dist')
        },
        target: 'node',
        devtool: 'inline-source-map'
    });
};
