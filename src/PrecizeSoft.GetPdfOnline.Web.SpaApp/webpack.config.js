const clientBundleConfig = require('./webpack/webpack.app.client.en-debug.js');
const serverBundleConfig = require('./webpack/webpack.app.server.en.js');

module.exports = (env) => {
    return clientBundleConfig(env);
    // return serverBundleConfig(env);
    // return [clientBundleConfig(env), serverBundleConfig(env)];
};
