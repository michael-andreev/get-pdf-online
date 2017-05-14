const webpackMerge = require('webpack-merge');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const { AotPlugin } = require('@ngtools/webpack');
const commonConfig = require('./webpack.common.js');
const helpers = require('./helpers');

module.exports = webpackMerge(commonConfig, {
  devtool: 'cheap-module-eval-source-map',

  entry: {
    'app': './src/main-jit.ts'
  },
  
  output: {
    path: helpers.root('dist'),
    publicPath: 'http://localhost:9435/',
    filename: '[name].bundle.js',
    chunkFilename: '[id].chunk.js'
  },

  plugins: [
    new ExtractTextPlugin('[name].css'),
    
    new HtmlWebpackPlugin({
      template: 'src/index-jit.html'
    }),
    new AotPlugin({
      "mainPath": "main-jit.ts",
      "hostReplacementPaths": {
        "environments\\environment.ts": "environments\\environment.ts"
      },
      "exclude": [],
      "tsConfigPath": "src\\tsconfig.app.json",
      "skipCodeGeneration": true
    })
  ],

  devServer: {
    historyApiFallback: true,
    stats: 'minimal'
  }
});