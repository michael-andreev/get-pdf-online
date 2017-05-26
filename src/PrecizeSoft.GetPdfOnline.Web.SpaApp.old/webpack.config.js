const clientBundleConfig = require('./webpack/webpack.app.client.aot.js');
const serverBundleConfig = require('./webpack/webpack.app.server.aot.js');

module.exports = (env) => {
    return clientBundleConfig(env);
    //return [clientBundleConfig(env), serverBundleConfig(env)];
}
