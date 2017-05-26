const webpack = require('webpack');
const { CommonsChunkPlugin } = require('webpack').optimize;
const helpers = require('./helpers');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
// const CheckerPlugin = require('awesome-typescript-loader').CheckerPlugin;

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    return {
        stats: { modules: false },
        context: helpers.root(),
        resolve: { extensions: ['.js', '.ts'] },
        output: {
            filename: '[name].js',
            publicPath: '/dist/' // Webpack dev middleware, if enabled, handles requests for this URL prefix
        },
        module: {
            rules: [
                {
                    test: /\.ts$/,
                    include: helpers.root('ClientApp'),
                    loader: '@ngtools/webpack'
                },
                // { test: /\.ts$/, include: /ClientApp/, use: ['awesome-typescript-loader?silent=true', 'angular2-template-loader'] },
                { test: /\.html$/, use: 'html-loader?minimize=false' },
                { test: /\.css$/, use: ['to-string-loader', isDevBuild ? 'css-loader' : 'css-loader?minimize'] },
                { test: /\.(png|jpg|jpeg|gif|svg)$/, use: 'url-loader?limit=25000' }
            ]
        }// ,
        // plugins: [new CheckerPlugin()]
    };
}
