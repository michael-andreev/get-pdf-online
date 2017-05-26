const webpack = require('webpack');
const merge = require('webpack-merge');
const helpers = require('./helpers');
const commonConfig = require('./webpack.vendor.js');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    return merge(commonConfig(env), {
        target: 'node',
        // resolve: { mainFields: ['main'] },
        output: {
            path: helpers.root('ClientApp', 'dist'),
            libraryTarget: 'commonjs2',
        },
        module: {
            rules: [{
                test: /\.css(\?|$)/,
                use: ['to-string-loader', isDevBuild ? 'css-loader' : 'css-loader?minimize']
            }]
        },
        entry: { vendor: ['aspnet-prerendering'] },
        plugins: [
            new webpack.DllPlugin({
                path: helpers.root('ClientApp', 'dist', '[name]-manifest.json'),
                name: '[name]_[hash]'
            })
        ]
    });
}
