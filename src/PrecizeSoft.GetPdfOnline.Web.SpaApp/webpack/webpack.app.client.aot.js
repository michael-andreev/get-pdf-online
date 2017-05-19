const webpack = require('webpack');
const merge = require('webpack-merge');
const helpers = require('./helpers');
const clientConfig = require('./webpack.app.client.js');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    return merge(clientConfig(env), {
    })
};
