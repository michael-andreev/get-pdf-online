const webpack = require('webpack');
const merge = require('webpack-merge');
const helpers = require('./helpers');
const commonConfig = require('./webpack.app.js');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    // Configuration for client-side bundle suitable for running in browsers
    return merge(commonConfig(env), {
        entry: { 'main-client': helpers.root('ClientApp', 'boot-client.ts') },
        output: { path: helpers.root('wwwroot', 'dist') },
        plugins: [
            new webpack.ContextReplacementPlugin(
                /angular(\\|\/)core(\\|\/)@angular/,
                helpers.root('ClientApp')
            ), // Workaround for https://github.com/angular/angular/issues/11580
            new webpack.DllReferencePlugin({
                context: helpers.root(),
                manifest: require(helpers.root('wwwroot', 'dist', 'vendor-manifest.json'))  
            })
        ].concat(isDevBuild ? [
            // Plugins that apply in development builds only
            new webpack.SourceMapDevToolPlugin({
                filename: '[file].map', // Remove this line if you prefer inline source maps
                moduleFilenameTemplate: helpers.root('wwwroot', 'dist', '[resourcePath]') // Point sourcemap entries to the original file locations on disk
            })
        ] : [
                // Plugins that apply in production builds only
                new webpack.optimize.UglifyJsPlugin()
            ])
    });
};
