const webpack = require('webpack');
const merge = require('webpack-merge');
const { GlobCopyWebpackPlugin } = require('@angular/cli/plugins/webpack');
const helpers = require('./helpers');
const commonConfig = require('./webpack.app.js');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    // Configuration for client-side bundle suitable for running in browsers
    return merge(commonConfig(env), {
        devtool: isDevBuild ? 'cheap-module-eval-source-map' : 'source-map',
        entry: {
            'main-client': [
                helpers.root('ClientApp', 'boot-client.ts')
            ],
            'polyfills': helpers.root('ClientApp', 'browser.polyfills.ts'),
            'vendor': helpers.root('ClientApp', 'browser.vendor.ts'),
            'styles': [
                helpers.root('ClientApp', 'styles.css')
            ]
        },
        output: {
            path: helpers.root('wwwroot', 'dist')
        },
        plugins: [
            /*new webpack.ContextReplacementPlugin(
                /angular(\\|\/)core(\\|\/)@angular/,
                helpers.root('ClientApp')
            ),*/ // Workaround for https://github.com/angular/angular/issues/11580
            /*new webpack.DllReferencePlugin({
                context: helpers.root(),
                manifest: require(helpers.root('wwwroot', 'dist', 'vendor-manifest.json'))  
            })*/
            new GlobCopyWebpackPlugin({
                'patterns': [
                'assets'
            ],
                'globOptions': {
                'cwd': helpers.root('ClientApp'),
                'dot': true,
                'ignore': '**/.gitkeep'
              }
            }),
            new webpack.optimize.CommonsChunkPlugin({
                name: ['app', 'vendor', 'polyfills']
            })
        ].concat(isDevBuild ? [
            // Plugins that apply in development builds only
            new webpack.SourceMapDevToolPlugin({
                filename: '[file].map', // Remove this line if you prefer inline source maps
                moduleFilenameTemplate: helpers.root('wwwroot', 'dist', '[resourcePath]') // Point sourcemap entries to the original file locations on disk
            })
        ] : [
                // Plugins that apply in production builds only
                new webpack.optimize.UglifyJsPlugin({
                    // https://github.com/angular/angular/issues/10618
                    // mangle: {
                    //   keep_fnames: true
                    // },
                    output: {
                        comments: false
                    }//,
                    //sourceMap: false
                })
            ])
    });
};
