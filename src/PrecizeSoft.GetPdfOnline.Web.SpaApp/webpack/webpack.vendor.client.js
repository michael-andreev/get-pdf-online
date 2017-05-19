const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const merge = require('webpack-merge');
const helpers = require('./helpers');
const commonConfig = require('./webpack.vendor.js');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);
    const extractCSS = new ExtractTextPlugin('vendor.css');

    return merge(commonConfig, {
        output: { path: helpers.root('wwwroot', 'dist') },
        module: {
            rules: [
                {
                    test: /\.css(\?|$)/,
                    use: extractCSS.extract({ use: isDevBuild ? 'css-loader' : 'css-loader?minimize' })
                }
            ]
        },
        plugins: [
            new webpack.ContextReplacementPlugin(
                /angular(\\|\/)core(\\|\/)@angular/,
                helpers.root('ClientApp')
            ), // Workaround for https://github.com/angular/angular/issues/11580
            extractCSS,
            new webpack.DllPlugin({
                path: helpers.root('wwwroot', 'dist', '[name]-manifest.json'),
                name: '[name]_[hash]'
            })
        ].concat(isDevBuild ? [] : [
            new webpack.optimize.UglifyJsPlugin()
        ])
    })
};
