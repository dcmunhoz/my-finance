module.exports = {
  "/api/auth/**": {
    target: process.env["services__identity-api__https__0"] ||
              process.env["services__identity-api__http__0"],
    secure: process.env["NODE_ENV"] === "production",
    changeOrigin: true,
  }
};
