const webpack = require('webpack');
const webpackMerge = require('webpack-merge');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const CompressionPlugin = require('compression-webpack-plugin');
const { AotPlugin } = require('@ngtools/webpack');
const commonConfig = require('./webpack.common.js');
const helpers = require('./helpers');
const nodeExternals = require('webpack-node-externals');

const ENV = process.env.NODE_ENV = process.env.ENV = 'production';

module.exports = webpackMerge(commonConfig, {
  devtool: 'source-map',

  entry: {
    // 'polyfills': './src/polyfills.ts',
    // 'vendor': './src/vendor.ts',
    'app': ['./src/uni/app.server.module.ts', './src/uni/server-aot.ts'],
    'styles': [
      './src/styles.css'
    ]
  },
  target: 'node',
  externals: [nodeExternals()],
  node: {
    global: true,
    crypto: true,
    __dirname: true,
    __filename: true,
    process: true,
    Buffer: true,
    fs: "empty"
  },    
  output: {
    path: helpers.root('dist'),
    publicPath: '/',
    // libraryTarget: 'commonjs',
    filename: '[name].js',
    chunkFilename: '[id].chunk.js'
  },

  plugins: [
    new webpack.NoEmitOnErrorsPlugin(),

    /*new webpack.optimize.UglifyJsPlugin({
      // https://github.com/angular/angular/issues/10618
      // mangle: {
      //   keep_fnames: true
      // },
      output: {
        comments: false
      },
      sourceMap: false
    }),*/

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
      // mainPath: 'uni/server-aot.ts',
      // entryModule: helpers.root('src', 'app', 'app.module#AppModule'),
      entryModule: helpers.root('src', 'uni', 'app.server.module#AppServerModule'),
      hostReplacementPaths: {
        'environments\\environment.ts': 'environments\\environment.prod.ts'
      },
      // "exclude": [],
      tsConfigPath: 'src\\tsconfig.uni.json' // ,
      // "skipCodeGeneration": true
    })
  ]
});
