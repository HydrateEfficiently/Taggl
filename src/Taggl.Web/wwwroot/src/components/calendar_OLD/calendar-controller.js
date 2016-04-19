import { Injectable } from './../../utility/injectable';
import { paths } from './../../paths';

export class CalendarController extends Injectable {
    static get $inject() {
        return ['$scope', 'TglLoggingService'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);

        this.$scope.$watch('ctrl.month', (value) => this.logger.debug(value), true);

        this.view = 'month';
        this.events = [];
    }

    selectDate(date) {
        return false;
    }

    _updateViewDate() {
        debugger;
        this.viewDate = this.monthMoment.toDate();
    }
}