'use strict';

import { Injectable } from './../../utility/injectable';

export class NavbarController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglSessionService'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.userInitials = this.TglSessionService.getUser().initials;

        this.items = [1, 2, 3];
    }

    isAdministrator() {
        return this.TglSessionService.isAdministrator();
    }

    logout() {
        this.TglSessionService.logout();
    }
}