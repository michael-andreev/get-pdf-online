const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const helpers = require('./helpers');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);
    // const extractCSS = new ExtractTextPlugin('vendor.css');

    return {
        stats: { modules: false },
        resolve: { extensions: ['.js'] },
        module: {
            rules: [
                {
                    test: /\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
                    loader: 'file-loader?name=assets/[name].[hash].[ext]'
                }
            ]
        },
        output: {
            publicPath: '/dist/',
            filename: '[name].js',
            library: '[name]_[hash]'
        },
        plugins: [
            new ExtractTextPlugin('[name].css'),
            new webpack.ProvidePlugin({ $: 'jquery', jQuery: 'jquery' }) // Maps these identifiers to the jQuery package (because Bootstrap expects it to be a global variable)
            // new webpack.ContextReplacementPlugin(/\@angular\b.*\b(bundles|linker)/, path.join(__dirname, './ClientApp')), // Workaround for https://github.com/angular/angular/issues/11580
            // new webpack.IgnorePlugin(/^vertx$/) // Workaround for https://github.com/stefanpenner/es6-promise/issues/100
        ].concat(isDevBuild ? [] : [
            // Plugins that apply in production builds only
            new webpack.optimize.UglifyJsPlugin({
                // https://github.com/angular/angular/issues/10618
                // mangle: {
                //   keep_fnames: true
                // },
                output: {
                    comments: false
                }//,
                //sourceMap: false
            })
        ])
    };
};
