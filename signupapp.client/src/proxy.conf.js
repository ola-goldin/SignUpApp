const PROXY_CONFIG = [
  {
    context: [
      "/users",
    ],
    target: "http://localhost:5185",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
