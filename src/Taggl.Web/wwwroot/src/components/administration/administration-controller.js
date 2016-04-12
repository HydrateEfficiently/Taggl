import { Injectable } from './../../utility/injectable';
import * as ArrayUtility from './../../utility/array-utility';

export class AdministrationController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.administrationApi = this.TglApiInterfaceFactory.createApiInterface('administration');

        this.pendingUsers = [];
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
}