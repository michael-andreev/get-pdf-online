const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const { GlobCopyWebpackPlugin } = require('@angular/cli/plugins/webpack');
const { CommonsChunkPlugin } = require('webpack').optimize;
const { AotPlugin } = require('@ngtools/webpack');
const helpers = require('./helpers');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {

  resolve: {
    extensions: [
      '.ts',
      '.js'
    ],
  },

  module: {
    rules: [
      {
        test: /\.ts$/,
        loader: '@ngtools/webpack'
      },
      {
        test: /\.html$/,
        loader: 'html-loader'
      },
      {
        test: /\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
        loader: 'file-loader?name=assets/[name].[hash].[ext]'
      },
      {
        test: /\.css$/,
        exclude: helpers.root('src', 'app'),
        loader: ExtractTextPlugin.extract(
          {
            fallback: 'style-loader',
            use: 'css-loader?sourceMap&minimize'
          })
      },
      {
        test: /\.css$/,
        include: helpers.root('src', 'app'),
        loader: 'raw-loader'
      }
    ]
  },

  plugins: [
    new GlobCopyWebpackPlugin({
      'patterns': [
        'assets',
        'favicon.ico'
      ],
      'globOptions': {
        'cwd': helpers.root('./src'),
        'dot': true,
        'ignore': '**/.gitkeep'
      }
    }),

    new webpack.ProvidePlugin({
      jQuery: 'jquery',
      $: 'jquery',
      jquery: 'jquery'
    }),

    new HtmlWebpackPlugin({
      template: 'src/index.html',
        minify: {
        removeAttributeQuotes: false,//Remove quotes around attributes when possible
        minifyJS: true, //Minify JavaScript in script elements and event attributes (uses UglifyJS)
        minifyCSS: true, //Minify CSS in style elements and style attributes (uses clean-css)
        removeComments: true, // Strip HTML comments
        // removeTagWhitespace: true, //Remove space between attributes whenever possible. Note that this will result in invalid HTML!
        trimCustomFragments: true, // Trim white space around ignoreCustomFragments.
        collapseWhitespace: true, //Collapse white space that contributes to text nodes in a document tree
        collapseInlineTagWhitespace: true, //Don't leave any spaces between display:inline; elements when collapsing. Must be used in conjunction with collapseWhitespace=true
      }
    }),

    new webpack.optimize.CommonsChunkPlugin({
      name: ['app', 'vendor', 'polyfills']
    })
  ]
};
