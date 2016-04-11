import { Injectable } from './../../utility/injectable';

export class ApiInterfaceFactory extends Injectable {
    static get $inject() {
        return ['TglHttpService', 'TglUrlService'];
    }

    constructor(...deps) {
        super(...deps);
    }

    createApiInterface(controllerName) {
        let controllerPath = `api.${controllerName}`;
        let actions = this.TglUrlService.getActions(controllerPath);
        let apiInterface = {};
        for (let actionName in actions) {
            let action = actions[actionName];
            apiInterface[actionName] = (...args) => {
                let url = action.urlPattern;
                if (action.parameterNames.length) {
                    let params = args.shift();
                    url = this.TglUrlService.resolveUrl(url, params);
                }
                return this.TglHttpService[action.method](url, ...args);
            };
        }
        return apiInterface;
    }
}