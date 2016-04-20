import { paths } from './../paths';
import * as angular from 'angular';

function camelCaseToDashed(str) {
    return str.replace(/(?:^|\.?)([A-Z])/g, (x, y) => `-${y.toLowerCase()}`).replace(/^_/, "");
}

export function componentFactory(name, controller, deps = [], bindToController = {}) {
    if (!angular.isString(name)) {
        throw new Error('Tried to create component without name');
    }

    if (!angular.isFunction(controller)) {
        throw new Error(`Component ${name} needs a controller`);
    }

    let prefixedName = `tgl${name.charAt(0).toUpperCase()}${name.substring(1)}`; 
    let dashedName = camelCaseToDashed(name);
    let moduleName = `tgl.components.${dashedName}`;
    let templateUrl = `/${paths.components}${dashedName}/${dashedName}.html`;

    const componentOptions = {
        restrict: 'E',
        scope: {},
        controller,
        controllerAs: 'ctrl',
        bindToController,
        templateUrl,
        replace: true
    };

    angular.module(moduleName, deps).directive(prefixedName, () => componentOptions);

    return moduleName;
}