import { Injectable } from './../../utility/injectable';
import * as ArrayUtility from './../../utility/array-utility';

export class AdministrationController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglHttpService', 'TglUrlService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.logger.debug('initialized');
        this.administrationApi = this.TglApiInterfaceFactory.createApiInterface('administration');
        this.searchApi = this.TglApiInterfaceFactory.createApiInterface('search');

        this.pendingUsers = [];
        this.userSearchResults = [];

        this.listPendingUsers();
    }

    listPendingUsers() {
        let model = this.pendingUsers;
        this.administrationApi.listPendingUsers({ model });
    }

    approveUser(user) {
        let pendingUsers = this.pendingUsers;
        this.administrationApi.approveUser(user.id)
            .then(() => ArrayUtility.remove(this.pendingUsers, user));
    }

    searchUsers() {
        if (this.userSearchPattern) {
            const maxAge = 5000;
            let model = this.userSearchResults;
            this.searchApi.users(this.userSearchPattern, { model, maxAge });
        }
    }
}