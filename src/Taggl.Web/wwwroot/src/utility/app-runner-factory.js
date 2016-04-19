import * as angular from 'angular';

export function appRunnerFactory(app, config) {
    return function (data) {
        app.constant('TglServerData', data);
        if (config) {
            app.config(config);
        }
        angular.element(document).ready(() => angular.bootstrap(document, [app.name]));
    };
}