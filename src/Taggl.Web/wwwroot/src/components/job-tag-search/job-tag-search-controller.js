import { Injectable } from './../../utility/injectable';

export class JobTagSearchController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.searchApi = this.TglApiInterfaceFactory.createApiInterface('search');

        this.jobTagSearchResults = [];
        if (this.initialModelJson) {
            this.selectedJobTag = JSON.parse(this.initialModelJson);
        }
    }

    getResults(pattern) {
        if (pattern) {
            return this.searchApi.jobTags(pattern, { maxAge: 10000 })
                .then(results => {
                    if (this.onResultsRetrieved && results.length) {
                        let resultsOverride = this.onResultsRetrieved({ results });
                        results = resultsOverride || results;
                    }
                    return results;
                });
        }
    }

    selectJobTag(item, model, event) {
        this.logger.debug('onItemSelected', item);

        this.onItemSelected({ item });
        if (this.clearOnSelect) {
            this.selectedJobTag = null;
        }

        event.stopImmediatePropagation();
    }

    createJobTag(label) {
        this.onItemCreated({ label });
        if (this.clearOnSelect) {
            this.selectedJobTag = null;
        }
    }
}