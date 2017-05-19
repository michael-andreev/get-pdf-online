const webpack = require('webpack');
const { CommonsChunkPlugin } = require('webpack').optimize;
const helpers = require('./helpers');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const CheckerPlugin = require('awesome-typescript-loader').CheckerPlugin;

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    return {
        stats: { modules: false },
        context: helpers.root(),
        entry: {
            // 'polyfills': helpers.root('ClientApp', 'polyfills.ts'),
            // 'vendor': helpers.root('ClientApp', 'vendor.ts')
        },
        resolve: { extensions: ['.js', '.ts'] },
        output: {
            filename: '[name].js',
            publicPath: '/dist/' // Webpack dev middleware, if enabled, handles requests for this URL prefix
            // publicPath: '/'
        },
        module: {
            rules: [
                /*{
                    test: /\.ts$/,
                    include: /ClientApp/,
                    loader: '@ngtools/webpack'
                },*/
                {
                    test: /\.ts$/,
                    include: /ClientApp/,
                    use: ['awesome-typescript-loader?silent=true', 'angular2-template-loader']
                },
                {
                    test: /\.html$/,
                    use: 'html-loader?minimize=false'
                },
                {
                    test: /\.css$/,
                    use: ['to-string-loader', isDevBuild ? 'css-loader' : 'css-loader?minimize']
                },
                {
                    test: /\.(png|jpg|jpeg|gif|svg)$/,
                    use: 'url-loader?limit=25000'
                },
                {
                    test: /\.(woff|woff2|eot|ttf)(\?|$)/,
                    use: 'url-loader?limit=100000'
                },
                /*{
                    test: /\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
                    loader: 'file-loader?name=assets/[name].[hash].[ext]'
                },
                {
                    test: /\.css$/,
                    exclude: helpers.root('ClienApp', 'app'),
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
                }*/
            ]
        },
        plugins: [
            // new ExtractTextPlugin('[name].css'),

            new webpack.ProvidePlugin({ $: 'jquery', jQuery: 'jquery' }), // Maps these identifiers to the jQuery package (because Bootstrap expects it to be a global variable)
            new CheckerPlugin(),

            /*new webpack.optimize.CommonsChunkPlugin({
                name: ['app', 'vendor', 'polyfills']
            })*/
        ]
    };
}
