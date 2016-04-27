'use strict';

import { Injectable } from './../../utility/injectable';

export class UserAvatarController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglUserService'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);

        let self = this;
        this.TglUserService.get(this.userId).then(user => self.user = user);
    }
}