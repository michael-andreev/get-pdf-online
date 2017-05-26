const webpack = require('webpack');
const merge = require('webpack-merge');
const CheckerPlugin = require('awesome-typescript-loader').CheckerPlugin;
const helpers = require('./helpers');
const clientConfig = require('./webpack.app.client.js');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    return merge(clientConfig(env), {
        module: {
            rules: [
                {
                    test: /\.ts$/,
                    include: /ClientApp/,
                    use: ['awesome-typescript-loader?silent=true', 'angular2-template-loader']
                }
            ]
        },
        plugins: [
            new CheckerPlugin()
        ]
    })
};
