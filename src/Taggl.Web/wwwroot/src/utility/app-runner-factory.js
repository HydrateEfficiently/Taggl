export function appRunnerFactory(app) {
    return function (data) {
        app.constant('TglServerData', data);
        angular.element(document).ready(() => angular.bootstrap(document, [app.name]));
    };
}