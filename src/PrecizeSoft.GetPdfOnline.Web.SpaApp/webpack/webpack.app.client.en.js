const webpack = require('webpack');
const merge = require('webpack-merge');
const { AotPlugin } = require('@ngtools/webpack');
const helpers = require('./helpers');
const commonConfig = require('./webpack.app.client.js');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    return merge(commonConfig(env), {
        entry: {
            'main-client.en': helpers.root('ClientApp', 'boot-client.ts')
        },
        plugins: [
            new AotPlugin({
                mainPath: helpers.root('ClientApp', 'boot-client.ts'),
                entryModule: helpers.root('ClientApp', 'app', 'app.module.client#AppModule'),
                tsConfigPath: helpers.root('ClientApp', 'tsconfig.client.json'),
                skipCodeGeneration: false
            })
        ]
    });
};
