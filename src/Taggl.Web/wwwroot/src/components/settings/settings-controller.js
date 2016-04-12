import { Injectable } from './../../utility/injectable';

export class SettingsController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglSessionService'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);

        this.personalInformation = this.TglSessionService.getUser().personalInformation;
    }
}