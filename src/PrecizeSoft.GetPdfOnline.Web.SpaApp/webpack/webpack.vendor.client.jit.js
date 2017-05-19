const webpack = require('webpack');
const merge = require('webpack-merge');
const helpers = require('./helpers');
const clientConfig = require('./webpack.vendor.client.js');

module.exports = (env) => {
    return merge(clientConfig(env), {
        entry: {
            vendor: ['@angular/compiler']
        }
    })
};
