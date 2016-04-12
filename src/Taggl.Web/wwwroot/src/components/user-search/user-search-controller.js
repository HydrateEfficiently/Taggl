import { Injectable } from './../../utility/injectable';

export class UserSearchController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.searchApi = this.TglApiInterfaceFactory.createApiInterface('search');

        this.userSearchResults = [];
        if (this.initialUser) {
            this.selectedUser = JSON.parse(this.initialUser);
        }
    }

    getResults(pattern) {
        if (pattern) {
            return this.searchApi.users(pattern, { maxAge: 10000 });
        }
    }

    selectUser(user) {
        this.logger.debug('onUserChanged', user);
        if (this.onUserChanged) {
            this.onUserChanged({ user });
        }
    }

    validateSelection() {
        if (!this.selectedUser) {
            this.selectUser(null);
        }
    }
}