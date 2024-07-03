const { merge } = require("webpack-merge");
const webpackConfig = require("./webpack.config.base");

module.exports = merge(webpackConfig, {
    mode: "production",
    output: {
        libraryTarget: 'umd',
        library: 'ReactOverlay'
    },
    externals: {
        'react': {
            commonjs: 'react',
            commonjs2: 'react',
            amd: 'react',
            root: 'React',
        },
        'react-dom': {
            commonjs: 'react-dom',
            commonjs2: 'react-dom',
            amd: 'react-dom',
            root: 'ReactDOM',
        },
    },
});
