import { Injectable } from './../../utility/injectable';

const SearchSource = {
    Users: 1,
    ShiftTypes: 2,
    Gyms: 4
};

class SearchController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.searchApi = this.TglApiInterfaceFactory.createApiInterface('search');

        this.searchResults = [];
        this.selectedResult = this.ngModel;
    }

    getResults(pattern) {
        if (pattern) {
            let sourceAction = this._getSourceAction();
            return this.searchApi[sourceAction](pattern, { maxAge: 10000 })
                .then(results => {
                    if (this.onResultsRetrieved && results.length) {
                        let resultsOverride = this.onResultsRetrieved({ results });
                        results = resultsOverride || results;
                    }
                    return results;
                });
        }
    }

    selectResult(item, model, event) {
        this.logger.debug('onItemSelected', item);

        this.onItemSelected({ item });
        if (this.clearOnSelect) {
            this.selectedResult = null;
        } else {
            this.selectedItem = item;
        }

        event.stopImmediatePropagation();
    }

    createResult(label) {
        if (this.createResults) {
            this.onItemCreated({ label });
            if (this.clearOnSelect) {
                this.selectedResult = null;
            }
        }
    }

    onBlur() {
        if (!this.selectedItem) {
            this.createResult(this.selectedResult);
        }
    }

    onChange() {
        this.selectedItem = null;
    }

    _getSourceAction() {
        switch (this.searchSource) {
            case SearchSource.Users:
                return "users";
            case SearchSource.ShiftTypes:
                return "shiftTypes";
            case SearchSource.Gyms:
                return "gyms";
            default:
                throw "Unrecognised search source";
        }
    }

}

export { SearchSource, SearchController };