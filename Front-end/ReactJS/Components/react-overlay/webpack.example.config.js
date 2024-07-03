const path = require('path');

const { merge } = require("webpack-merge");
const webpackConfig = require("./webpack.config.base");

module.exports = merge(webpackConfig, {
    context: path.resolve(__dirname, 'example'),
    entry: {
        'index': './index.jsx',
        'style': './index.scss'
    },
    output: {
        path: path.resolve(__dirname, 'example/dist'),
    }
})