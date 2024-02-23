const path = require("path");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const { CleanWebpackPlugin } = require("clean-webpack-plugin");
const TerserPlugin = require("terser-webpack-plugin");

module.exports = (env) => {
  const isDevBuild = process.env.NODE_ENV === "development";

  const clientBundleConfig = {
    mode: process.env.NODE_ENV,
    entry: {
      index: "./src/js/index.js",
      style: "./src/style/index.scss",
    },
    output: {
      path: path.resolve(__dirname, "dist"),
      filename: "[name].js",
      libraryTarget: "umd",
      library: "ReactDatePicker",
    },
    resolve: { extensions: [".js", ".jsx"] },
    module: {
      rules: [
        {
          test: /\.(js|jsx)$/,
          use: "babel-loader",
          exclude: /node_modules/,
        },
        {
          test: /\.(sc|c)ss$/,
          use: [MiniCssExtractPlugin.loader, "css-loader", "sass-loader"],
        },
      ],
    },
    plugins: [
      new CleanWebpackPlugin(),
      new MiniCssExtractPlugin({
        filename: "[name].css",
        chunkFilename: "[id].css",
      }),
    ],
    optimization: {
      minimize: true,
      minimizer: [
        new TerserPlugin({
          terserOptions: {
            compress: {
              drop_console: true,
            },
          },
          extractComments: false,
        }),
      ],
    },
    devtool: isDevBuild ? "source-map" : undefined,
    externals: isDevBuild
      ? {}
      : {
          react: {
            root: "React",
            commonjs2: "react",
            commonjs: "react",
            amd: "react",
          },
          moment: {
            root: "moment",
            commonjs2: "moment",
            commonjs: "moment",
            amd: "moment",
          },
        },
    watch: isDevBuild,
  };

  return clientBundleConfig;
};
