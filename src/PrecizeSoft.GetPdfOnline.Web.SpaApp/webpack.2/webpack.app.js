const webpack = require('webpack');
const { CommonsChunkPlugin } = require('webpack').optimize;
const helpers = require('./helpers');
const ExtractTextPlugin = require('extract-text-webpack-plugin');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    return {
        /*devServer: {
            historyApiFallback: true,
            stats: 'minimal'
        },*/
        stats: { modules: false },
        context: helpers.root(),
        resolve: { extensions: ['.ts', '.js'] },
        output: {
            filename: isDevBuild ? '[name].js' : '[name].js',
            chunkFilename: isDevBuild ? '[id].chunk.js' : '[id].[hash].chunk.js',
            publicPath: '/dist/' // Webpack dev middleware, if enabled, handles requests for this URL prefix
            //publicPath: '/'
        },
        module: {
            rules: [
                {
                    test: /\.html$/,
                    use: 'html-loader?minimize=false'
                },
                {
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
                },
                {
                    test: /\.css$/,
                    include: helpers.root('ClientApp', 'app'),
                    loader: 'raw-loader'
                }
            ]
        },
        plugins: [
            new ExtractTextPlugin('[name].css'),
            new webpack.ProvidePlugin({ $: 'jquery', jQuery: 'jquery' }) // Maps these identifiers to the jQuery package (because Bootstrap expects it to be a global variable)
        ].concat(isDevBuild ? [
            // Plugins that apply in development builds only
        ] : [
                // Plugins that apply in production builds only
                // new webpack.optimize.UglifyJsPlugin()
            ])
    };
}
