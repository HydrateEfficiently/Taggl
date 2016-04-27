'use strict';

import { Injectable } from './../../utility/injectable';

export class UserService extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglApiInterfaceFactory', 'TglSessionService'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.userApi = this.TglApiInterfaceFactory.createApiInterface('user');
    }

    get(id) {
        let currentUser = this.TglSessionService.getUser();
        if (currentUser.id === id) {
            return new Promise(resolve => resolve(currentUser)) ;
        }
        return this.userApi.get(id);
    }
}