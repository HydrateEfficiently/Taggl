import { Injectable } from './../../utility/injectable';
import * as ArrayUtility from './../../utility/array-utility';

export class AdministrationController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglHttpService', 'TglUrlService'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.logger.debug('initialized');

        this.pendingUsers = [];
        this.userSearchResults = [];

        this.listPendingUsers();
    }

    listPendingUsers() {
        let url = this.TglUrlService.getUrl('api.administration.listPendingUsers');
        this.TglHttpService.getModel(url, this.pendingUsers);
    }

    approveUser(user) {
        let url = this.TglUrlService.getUrl('api.administration.approveUser', user.id);
        this.TglHttpService.post(url).then(result => ArrayUtility.remove(this.pendingUsers, user));
    }

    searchUsers() {
        debugger;
        let url = this.TglUrlService.getUrl('api.search.users', this.userSearchPattern);
        this.TglHttpService.getModel(url, this.userSearchResults);
    }
}