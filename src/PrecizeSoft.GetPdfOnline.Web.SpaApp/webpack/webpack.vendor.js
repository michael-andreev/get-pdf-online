const webpack = require('webpack');
// const ExtractTextPlugin = require('extract-text-webpack-plugin');
const helpers = require('./helpers');

module.exports = (env) => {
    // const extractCSS = new ExtractTextPlugin('vendor.css');
    const isDevBuild = !(env && env.prod);

    return {
        stats: { modules: false },
        resolve: { extensions: ['.js'] },
        module: {
            rules: [
                {
                    test: /\.(png|woff|woff2|eot|ttf|svg)(\?|$)/,
                    use: 'url-loader?limit=100000'
                }
            ]
        },
        entry: {
            vendor: [
                '@angular/animations',
                '@angular/common',
                '@angular/compiler',
                '@angular/core',
                '@angular/forms',
                '@angular/http',
                '@angular/platform-browser',
                '@angular/platform-browser-dynamic',
                '@angular/router',
                'bootstrap',
                'bootstrap/dist/css/bootstrap.css',
                'es6-shim',
                'es6-promise',
                'event-source-polyfill',
                'jquery',
                'zone.js',
            ]
        },
        output: {
            publicPath: '/dist/',
            filename: '[name].js',
            library: '[name]_[hash]'
        },
        plugins: [
            new webpack.ProvidePlugin({ $: 'jquery', jQuery: 'jquery' })/*, // Maps these identifiers to the jQuery package (because Bootstrap expects it to be a global variable)
            new webpack.ContextReplacementPlugin(
                /\@angular\b.*\b(bundles|linker)/,
                helpers.root('ClientApp')
            ), // Workaround for https://github.com/angular/angular/issues/11580
            new webpack.ContextReplacementPlugin(
                /angular(\\|\/)core(\\|\/)@angular/,
                helpers.root('ClientApp')
            ), // Workaround for https://github.com/angular/angular/issues/14898
            new webpack.IgnorePlugin(/^vertx$/)*/ // Workaround for https://github.com/stefanpenner/es6-promise/issues/100
        ]
    };
};
