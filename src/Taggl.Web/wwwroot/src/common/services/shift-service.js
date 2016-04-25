import * as angular from 'angular';

import { Injectable } from './../../utility/injectable';

export class SessionService extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.shiftScheduleApi = this.TglApiInterfaceFactory.createApiInterface('shiftSchedule');
    }

    getShiftSchedule(id) {
        
    }
}