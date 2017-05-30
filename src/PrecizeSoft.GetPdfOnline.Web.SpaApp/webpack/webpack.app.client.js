const webpack = require('webpack');
const merge = require('webpack-merge');
// const { GlobCopyWebpackPlugin } = require('@angular/cli/plugins/webpack');
const { AotPlugin } = require('@ngtools/webpack');
const helpers = require('./helpers');
const commonConfig = require('./webpack.app.js');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    // Configuration for client-side bundle suitable for running in browsers
    return merge(commonConfig(env), {
        entry: {
            'main-client': helpers.root('ClientApp', 'boot-client.ts'),
            'styles': [
                helpers.root('ClientApp', 'styles.css')
            ]
        },
        output: { path: helpers.root('wwwroot', 'dist') },
        /*module: {
            rules: [
                {
                    test: /\.ts$/,
                    include: /ClientApp/,
                    loader: '@ngtools/webpack'
                }
            ]
        },*/
        plugins: [
            new webpack.DllReferencePlugin({
                context: helpers.root(),
                manifest: require(helpers.root('wwwroot', 'dist', 'vendor-manifest.json'))
            }),
            new AotPlugin({
                mainPath: helpers.root('ClientApp', 'boot-client.ts'),
                entryModule: helpers.root('ClientApp', 'app', 'app.module.client#AppModule'),
                // entryModule: './ClientApp\\app\\app.module.client#AppModule',
                tsConfigPath: helpers.root('tsconfig.json'),
                skipCodeGeneration: true
            })
        ].concat(isDevBuild ? [
            // Plugins that apply in development builds only
            new webpack.SourceMapDevToolPlugin({
                filename: '[file].map', // Remove this line if you prefer inline source maps
                moduleFilenameTemplate: helpers.root('wwwroot', 'dist', '[resourcePath]') // Point sourcemap entries to the original file locations on disk
            })
        ] : [])
    });
};
