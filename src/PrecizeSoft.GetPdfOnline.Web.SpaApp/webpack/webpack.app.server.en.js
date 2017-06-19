const webpack = require('webpack');
const merge = require('webpack-merge');
const { AotPlugin } = require('@ngtools/webpack');
const helpers = require('./helpers');
const commonConfig = require('./webpack.app.server.js');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    return merge(commonConfig(env), {
        entry: { 'main-server.en' : helpers.root('ClientApp', 'boot-server.ts') },
        plugins: [
            new AotPlugin({
                mainPath: helpers.root('ClientApp', 'boot-server.ts'),
                // entryModule: helpers.root('ClientApp', 'app', 'app.module.server#AppModule'),
                tsConfigPath: helpers.root('ClientApp', 'tsconfig.server.json'),
                skipCodeGeneration: false
            })
        ]
    });
};
