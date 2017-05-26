const webpack = require('webpack');
const merge = require('webpack-merge');
const helpers = require('./helpers');
const commonConfig = require('./webpack.vendor.js');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    return merge(commonConfig(env), {
        entry: {
            vendor: [
                helpers.root('ClientApp', 'server.polyfills.ts'),
                helpers.root('ClientApp', 'server.vendor.ts')
            ]
        },
        target: 'node',
        resolve: { mainFields: ['main'] },
        output: {
            path: helpers.root('ClientApp', 'dist'),
            libraryTarget: 'commonjs2',
        },
        module: {
            rules: [{ test: /\.css(\?|$)/, use: ['to-string-loader', isDevBuild ? 'css-loader' : 'css-loader?minimize'] }]
        },
        plugins: [
            /*new webpack.ContextReplacementPlugin(
                /@angular\b.*\b(bundles|linker)/,
                helpers.root('ClientApp')
            ),*/ // Workaround for https://github.com/angular/angular/issues/11580
            new webpack.DllPlugin({
                path: helpers.root('ClientApp', 'dist', '[name]-manifest.json'),
                name: '[name]_[hash]'
            })
        ]
    })
};
