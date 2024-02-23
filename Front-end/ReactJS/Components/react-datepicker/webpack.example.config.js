const path = require("path");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const { CleanWebpackPlugin } = require("clean-webpack-plugin");
const TerserPlugin = require("terser-webpack-plugin");
module.exports = {
    mode: 'production',
    entry: {
        'index': './example/app.js',
        'style': './example/style.scss'
    },
    output: {
        filename: '[name].js',
        path: path.resolve(__dirname, './example/dist/')
    },
    resolve: {
        extensions: [".js", ".jsx"],
    },
    module: {
        rules: [{
            test: /\.(js|jsx)$/,
            use: 'babel-loader',
            exclude: /node_modules/,
        },
        {
            test: /\.(sc|c)ss$/,
            use: [
                MiniCssExtractPlugin.loader,
                'css-loader',
                'sass-loader',
            ]
        }
        ]
    },
    plugins: [
        new CleanWebpackPlugin(),
        new MiniCssExtractPlugin({ filename: "[name].css", chunkFilename: '[id].css' })
    ],
    devServer: {
        static: path.join(__dirname, "./example"),
        compress: true,
        port: 9001,
        devMiddleware: {
            writeToDisk: true,
        },
        client: {
            overlay: {
              errors: true,
              warnings: false,
              runtimeErrors: true,
            },
        }
    },
    optimization: {
        minimize: true,
        minimizer: [new TerserPlugin({
            extractComments: false,
            terserOptions: {
                format: {
                    comments: false,
                },
            }
        })],
    },
    devtool: "source-map"
}