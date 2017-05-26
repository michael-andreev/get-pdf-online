const clientBundleConfig = require('./webpack/webpack.vendor.client.js');
const serverBundleConfig = require('./webpack/webpack.vendor.server.js');

module.exports = (env) => {
    return [clientBundleConfig(env), serverBundleConfig(env)];
}
