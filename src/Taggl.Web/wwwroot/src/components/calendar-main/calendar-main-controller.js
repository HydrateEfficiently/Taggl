import { Injectable } from './../../utility/injectable';

export class CalendarMainController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', '$state'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
    }

    addShift() {
        this.$state.go('calendar.addShift');
    }
}