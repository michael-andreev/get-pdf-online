const webpack = require('webpack');
const { CommonsChunkPlugin } = require('webpack').optimize;
const CompressionPlugin = require('compression-webpack-plugin');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const helpers = require('./helpers');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    return {
        stats: { modules: false },
        context: helpers.root(),
        resolve: { extensions: ['.js', '.ts'] },
        output: {
            filename: '[name].js',
            publicPath: '/dist/' // Webpack dev middleware, if enabled, handles requests for this URL prefix
        },
        module: {
            rules: [
                {
                    test: /\.ts$/,
                    include: helpers.root('ClientApp'),
                    loader: '@ngtools/webpack'
                },
                { test: /\.html$/, use: 'html-loader?minimize=false' },
                /*{
                    test: /\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
                    loader: 'file-loader?name=assets/[name].[hash].[ext]'
                },
                {
                    test: /\.css$/,
                    exclude: helpers.root('ClientApp', 'app'),
                    loader: ExtractTextPlugin.extract(
                        {
                            fallback: 'style-loader',
                            use: 'css-loader?sourceMap&minimize'
                        })
                },*/
                {
                    test: /\.css$/,
                    include: helpers.root('ClientApp', 'app'),
                    loader: 'raw-loader'
                }
            ]
        },
        plugins: [
            new ExtractTextPlugin('[name].css')
        ].concat(isDevBuild ? [] : [
            // Plugins that apply in production builds only
            new webpack.NoEmitOnErrorsPlugin(),
            new webpack.optimize.UglifyJsPlugin({
                // https://github.com/angular/angular/issues/10618
                // mangle: {
                //   keep_fnames: true
                // },
                output: {
                    comments: false
                }//,
                //sourceMap: false
            }),
            new CompressionPlugin({
                asset: "[path].gz[query]",
                algorithm: "gzip",
                test: /\.(js|html|css)$/,
                threshold: 10240,
                minRatio: 0.8
            })
        ])
    };
}
