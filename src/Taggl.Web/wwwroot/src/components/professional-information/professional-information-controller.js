import { Injectable } from './../../utility/injectable';

export class ProfessionalInformationController extends Injectable {
    static get $inject() {
        return ['TglLoggingService'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
    }
}