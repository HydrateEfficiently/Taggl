import { Injectable } from './../../utility/injectable';

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
        let logger = this.logger;
        return this._getGetRequest(url, options.maxAge)
            .then(result => {
                logger.debug(result);

                let data = result.data;
                let model = options.model;
                if (model) {
                    if (angular.isArray(model)) {
                        model.length = 0;
                        model.push(...data);
                    } else if (angular.isObject(model)) {
                        angular.merge(model, data);
                    }
                }

                return data;
            });
    }

    post(...args) {
        let logger = this.logger;
        return this.$http.post(...args).then(result => {
            logger.debug(result);
            return result.data;
        });
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
}