import { Injectable } from './../../utility/injectable';

export class CalendarMainController extends Injectable {
    static get $inject() {
        return ['$scope', '$state', 'TglLoggingService', '$state'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);

        if (this.$state.is('calendar')) {
            this.getSchedule(new Date());
        }
    }

    getSchedule(date) {
        let timestamp = moment(date).startOf('day').toDate().getTime();
        this.$state.go('calendar.day', { timestamp });
    }
}