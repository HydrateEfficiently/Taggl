import { Injectable } from './../../utility/injectable';

export class UrlService extends Injectable {
    static get $inject() {
        return ['TglServerData'];
    }

    constructor(...deps) {
        super(...deps);

        this.serverData = this.TglServerData;
    }

    getUrl(actionPath, params) {
        let config = this._getConfig(actionPath);
        let url = this.resolveUrl(config.urlPattern, params);
        return url;
    }

    getActions(controllerPath) {
        let config = this._getConfig(controllerPath);
        return config;
    }

    resolveUrl(url, params) {
        if (params) {
            let paramsToReplace = url.split('/').filter(s =>
                s.indexOf(encodeURIComponent(':').toLowerCase()) === 0);

            if (typeof params !== 'object') {
                if (paramsToReplace.length === 1) {
                    url = url.replace(paramsToReplace[0], params);
                    return url;
                }
            }

            for (let key in params) {
                let param = encodeURIComponent(`:${key}`).toLowerCase();
                url = url.replace(param, params[key]);
            }
        }
        return url;
    }

    _getConfig(path) {
        let config = this._getActionData();
        if (!config) {
            throw 'No actions were configured for this page.';
        }

        let pathComponents = path.split('.');
        for (let i = 0; i < pathComponents.length; i++) {
            config = config[pathComponents[i]];
            if (!config) {
                throw `Could not find action with path ${pathComponents}`;
            }
        }

        return config;
    }

    _getActionData() {
        return this.serverData && this.serverData.actions ? this.serverData.actions : null;
    }
}