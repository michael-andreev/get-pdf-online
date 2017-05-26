const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const merge = require('webpack-merge');
const helpers = require('./helpers');
const commonConfig = require('./webpack.vendor.js');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);
    // const extractCSS = new ExtractTextPlugin('vendor.css');

    return merge(commonConfig(env), {
        entry: {
            vendor: [
                helpers.root('ClientApp', 'browser.polyfills.ts'),
                helpers.root('ClientApp', 'browser.vendor.ts')
            ]
        },
        output: { path: helpers.root('wwwroot', 'dist') },
        module: {
            rules: [
                /*{
                    test: /\.css(\?|$)/,
                    use: extractCSS.extract({ use: isDevBuild ? 'css-loader' : 'css-loader?minimize' })
                },*/
                {
                    test: /\.css(\?|$)/,
                    loader: ExtractTextPlugin.extract(
                        {
                            fallback: 'style-loader',
                            use: isDevBuild ? 'css-loader?sourceMap' : 'css-loader?minimize'
                        })
                }
           ]
        },
        plugins: [
            new ExtractTextPlugin('[name].css'),
            /*new webpack.ContextReplacementPlugin(
                /angular(\\|\/)core(\\|\/)@angular/,
                helpers.root('ClientApp')
            ),*/ // Workaround for https://github.com/angular/angular/issues/11580
            //extractCSS,
            new webpack.DllPlugin({
                path: helpers.root('wwwroot', 'dist', '[name]-manifest.json'),
                name: '[name]_[hash]'
            })
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
    })
};
