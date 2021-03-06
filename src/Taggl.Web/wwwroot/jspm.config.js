SystemJS.config({
  transpiler: "plugin-babel",
  packages: {
    "app": {
      "main": "app.js",
      "meta": {
        "*.js": {
          "loader": "plugin-babel"
        }
      }
    }
  }
});

SystemJS.config({
  packageConfigPaths: [
    "npm:@*/*.json",
    "npm:*.json",
    "github:*/*.json"
  ],
  map: {
    "angular": "github:angular/bower-angular@1.5.3",
    "angular-bootstrap-calendar": "npm:angular-bootstrap-calendar@0.19.6",
    "angular-touch": "npm:angular-touch@1.5.5",
    "angular-ui-bootstrap": "npm:angular-ui-bootstrap@1.3.1",
    "angular-ui-router": "github:angular-ui/ui-router@0.2.18",
    "bootstrap": "github:twbs/bootstrap@3.3.6",
    "bootstrap-sass": "github:twbs/bootstrap-sass@3.3.6",
    "bootswatch": "npm:bootswatch@3.3.6",
    "buffer": "github:jspm/nodelibs-buffer@0.2.0-alpha",
    "css": "github:systemjs/plugin-css@0.1.20",
    "font-awesome": "npm:font-awesome@4.5.0",
    "interact.js": "npm:interact.js@1.2.6",
    "less.js": "github:less/less.js@2.6.1",
    "lodash": "npm:lodash@4.11.1",
    "moment": "npm:moment@2.12.0",
    "plugin-babel": "npm:systemjs-plugin-babel@0.0.9",
    "process": "github:jspm/nodelibs-process@0.2.0-alpha"
  },
  packages: {
    "github:angular-ui/ui-router@0.2.18": {
      "map": {
        "angular": "github:angular/bower-angular@1.5.3"
      }
    },
    "github:jspm/nodelibs-buffer@0.2.0-alpha": {
      "map": {
        "buffer-browserify": "npm:buffer@4.6.0"
      }
    },
    "github:twbs/bootstrap@3.3.6": {
      "map": {
        "jquery": "github:components/jquery@2.2.1"
      }
    },
    "npm:buffer@4.6.0": {
      "map": {
        "base64-js": "npm:base64-js@1.1.2",
        "ieee754": "npm:ieee754@1.1.6",
        "isarray": "npm:isarray@1.0.0"
      }
    },
    "npm:font-awesome@4.5.0": {
      "map": {
        "css": "github:systemjs/plugin-css@0.1.20"
      }
    }
  }
});
