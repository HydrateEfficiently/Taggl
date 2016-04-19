import { Injectable } from './../../utility/injectable';

export class CalendarController extends Injectable {
    static get $inject() {
        return ['$scope', 'TglLoggingService'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.date = new Date();

        this.today = new Date();

        this.datepickerOptions = {
            maxMode: 'day'
        };

        this.$scope.isToday = this.isToday;
    }

    isToday(date) {
        date;
        debugger;
    }
}