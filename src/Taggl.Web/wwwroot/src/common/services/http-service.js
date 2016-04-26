import * as angular from 'angular';

import { Injectable } from './../../utility/injectable';
import { LoadStatus } from './../../utility/load-status';

export class HttpService extends Injectable {
    static get $inject() {
        return ['$http', 'TglLoggingService'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.getCache = {};
    }

    get(url, options = {}) {
        var self = this;
        return this._getGetRequest(url, options.maxAge).then(result =>
            self._onResult(result, options));
    }

    post(url, data, options = {}) {
        var self = this;
        return this.$http.post(url, data).then(result =>
            self._onResult(result, options));
    }

    _getGetRequest(url, maxAge = 0) {
        let requestTime = new Date().getTime();
        let responseFromCache = this.getCache[url];
        if (!responseFromCache || responseFromCache.requestTime < (requestTime - maxAge)) {
            let responsePromise = this.$http.get(url);
            responseFromCache = { requestTime, responsePromise };
            this.getCache[url] = responseFromCache;
        }
        return responseFromCache.responsePromise;
    }

    _onResult(result, options) {
        this.logger.debug(result);
        let data = result.data;

        if (options.model) {
            this._updateModel(options.model, data);
        } else if (options.models) {
            options.models.forEach(m => {
                this._updateModel(m, data);
            });
        }

        if (options.loadStatusContainer) {
            options.loadStatusContainer.value = LoadStatus.Loaded;
        }

        return data;
    }

    _updateModel(model, data) {
        if (angular.isArray(model)) {
            model.length = 0;
            model.push(...data);
        } else if (angular.isObject(model)) {
            for (let key in data) {
                model[key] = angular.copy(data[key]);
            }
        }
    }
}