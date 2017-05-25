const webpack = require('webpack');
const merge = require('webpack-merge');
const { AotPlugin } = require('@ngtools/webpack');
const helpers = require('./helpers');
const clientConfig = require('./webpack.app.client.js');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    return merge(clientConfig(env), {
        module: {
            rules: [
                {
                    test: /\.ts$/,
                    include: helpers.root('ClientApp'),
                    loader: '@ngtools/webpack'
                }
            ]
        },
        plugins: [
            new AotPlugin({
                mainPath: helpers.root('ClientApp', 'boot-client.ts'),
                entryModule: helpers.root('ClientApp', 'app', 'browser-app.module#BrowserAppModule'),
                hostReplacementPaths: {
                    'ClientApp\\environments\\environment.ts':
                        isDevBuild ? 'ClientApp\\environments\\environment.ts' : 'ClientApp\\environments\\environment.prod.ts'
                },
                tsConfigPath: helpers.root('tsconfig.json'),
                skipCodeGeneration: true
            })
        ]
    })
};
