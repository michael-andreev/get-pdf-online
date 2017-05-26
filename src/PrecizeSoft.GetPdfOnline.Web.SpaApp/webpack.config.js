const clientBundleConfig = require('./webpack/webpack.app.client.js');
const serverBundleConfig = require('./webpack/webpack.app.server.js');

module.exports = (env) => {
    // return clientBundleConfig(env);
    return [clientBundleConfig(env), serverBundleConfig(env)];
}
