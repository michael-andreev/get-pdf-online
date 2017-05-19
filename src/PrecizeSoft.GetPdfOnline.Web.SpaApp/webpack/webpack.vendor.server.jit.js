const webpack = require('webpack');
const merge = require('webpack-merge');
const helpers = require('./helpers');
const serverConfig = require('./webpack.vendor.server.js');

module.exports = (env) => {
    return merge(serverConfig(env), {
        entry: {
            vendor: ['@angular/compiler']
        }
    })
};
