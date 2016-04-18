import { Injectable } from './../../utility/injectable';

export class ShiftFormController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', '$timeout'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);

        // let self = this;
        // this.$timeout(this.saveShift, 5000);
    }
}