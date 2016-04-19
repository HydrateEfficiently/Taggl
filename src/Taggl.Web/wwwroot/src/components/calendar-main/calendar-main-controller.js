import { Injectable } from './../../utility/injectable';

export class CalendarMainController extends Injectable {
    static get $inject() {
        return ['$scope', 'TglLoggingService', '$state'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);

        this.calendarMonthMoment = moment().startOf('month');
        this.calendarMonth = new Date(0);
        this._updateMonth();
    }

    nextMonth() {
        this.calendarMonthMoment.add(1, 'months');
        this._updateMonth();
    }

    previousMonth() {
        this.calendarMonthMoment.subtract(1, 'months');
        this._updateMonth();
    }

    addShift() {
        this.$state.go('calendar.addShift');
    }

    _updateMonth() {
        this.calendarMonth.setTime(this.calendarMonthMoment.toDate().getTime());
    }
}