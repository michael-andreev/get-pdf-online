const webpack = require('webpack');
const helpers = require('./helpers');

module.exports = {
    stats: { modules: false },
    resolve: { extensions: ['.js'] },
    module: {
        rules: [
            { test: /\.(png|woff|woff2|eot|ttf|svg)(\?|$)/, use: 'url-loader?limit=100000' }
        ]
    },
    entry: {
        vendor: [
            helpers.root('ClientApp', 'polyfills.ts'),
            helpers.root('ClientApp', 'vendor.ts'),
            // '@angular/compiler',
            // 'es6-shim',
            // 'es6-promise',
            // 'event-source-polyfill',
        ]
    },
    output: {
        publicPath: '/dist/',
        filename: '[name].js',
        library: '[name]_[hash]'
    },
    plugins: [
        new webpack.ProvidePlugin({ $: 'jquery', jQuery: 'jquery' }), // Maps these identifiers to the jQuery package (because Bootstrap expects it to be a global variable)
        // new webpack.ContextReplacementPlugin(/\@angular\b.*\b(bundles|linker)/, path.join(__dirname, './ClientApp')), // Workaround for https://github.com/angular/angular/issues/11580
        // new webpack.IgnorePlugin(/^vertx$/) // Workaround for https://github.com/stefanpenner/es6-promise/issues/100
    ]
}
