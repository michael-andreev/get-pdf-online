const webpackMerge = require('webpack-merge');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const { AotPlugin } = require('@ngtools/webpack');
const commonConfig = require('./webpack.common.js');
const helpers = require('./helpers');

module.exports = webpackMerge(commonConfig, {
  devtool: 'cheap-module-eval-source-map',

  entry: {
    'polyfills': './src/polyfills.ts',
    'vendor': './src/vendor.ts',
    'app': './src/main.ts',
    'styles': [
      './src/styles.css'
    ]
  },

  output: {
    path: helpers.root('dist'),
    publicPath: 'http://localhost:9435/',
    filename: '[name].bundle.js',
    chunkFilename: '[id].chunk.js'
  },

  plugins: [
    new ExtractTextPlugin('[name].css'),
    
    new AotPlugin({
      mainPath: "main.ts",
      entryModule: helpers.root('src', 'app', 'app.module#AppModule'),
      hostReplacementPaths: {
        'environments\\environment.ts': 'environments\\environment.ts'
      },
      tsConfigPath: 'src\\tsconfig.app.json',
      skipCodeGeneration: true
    })
  ],

  devServer: {
    historyApiFallback: true,
    stats: 'minimal'
  }
});