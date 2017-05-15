const webpack = require('webpack');
const webpackMerge = require('webpack-merge');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const CompressionPlugin = require('compression-webpack-plugin');
const { AotPlugin } = require('@ngtools/webpack');
const commonConfig = require('./webpack.common.js');
const helpers = require('./helpers');

const ENV = process.env.NODE_ENV = process.env.ENV = 'production';

module.exports = webpackMerge(commonConfig, {
  devtool: 'source-map',

  output: {
    path: helpers.root('dist'),
    publicPath: '/',
    filename: '[name].[hash].js',
    chunkFilename: '[id].[hash].chunk.js'
  },

  plugins: [
    new webpack.NoEmitOnErrorsPlugin(),

    new webpack.optimize.UglifyJsPlugin({
      // https://github.com/angular/angular/issues/10618
      // mangle: {
      //   keep_fnames: true
      // },
      output: {
        comments: false
      },
      sourceMap: false
    }),

    new CompressionPlugin({
        asset: "[path].gz[query]",
        algorithm: "gzip",
        test: /\.(js|html|css)$/,
        threshold: 10240,
        minRatio: 0.8
    }),
    
    new ExtractTextPlugin('[name].[hash].css'),

    new webpack.DefinePlugin({
      'process.env': {
        'ENV': JSON.stringify(ENV)
      }
    }),

    /*new webpack.LoaderOptionsPlugin({
      htmlLoader: {
        minimize: false // workaround for ng2
      }
    }),*/

    new AotPlugin({
      mainPath: 'main.ts',
      // entryModule: helpers.root('src', 'app', 'app.module#AppModule'),
      hostReplacementPaths: {
        'environments\\environment.ts': 'environments\\environment.prod.ts'
      },
      // "exclude": [],
      tsConfigPath: 'src\\tsconfig.app.json' // ,
      // "skipCodeGeneration": true
    })
  ]
});
