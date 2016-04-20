import { Injectable } from './../../utility/injectable';

export class CalendarController extends Injectable {
    static get $inject() {
        return ['$scope', 'TglLoggingService'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.date = new Date();

        this.$scope.$watch(
            () => this.date,
            (date) => {
                if (this.onDateSelected) {
                    this.onDateSelected({ date });
                }
            },
            true);

        this.datepickerOptions = {
            maxMode: 'day'
        };
    }
}