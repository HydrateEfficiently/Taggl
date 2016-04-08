import { paths } from './../paths';

function camelCaseToDashed(str) {
    return str.replace(/(?:^|\.?)([A-Z])/g, (x, y) => `-${y.toLowerCase()}`).replace(/^_/, "");
}

export function componentFactory(name, controller, deps = [], directiveOptions = {}) {
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

    let options = {
        controllerAs: 'ctrl'
    };
    angular.extend(options, directiveOptions);

    const componentOptions = {
        controller,
        templateUrl,
        restrict: 'E',
        scope: {}
    };
    angular.merge(options, componentOptions);

    angular.module(moduleName, deps).directive(prefixedName, () => options);

    return moduleName;
}