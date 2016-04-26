import { Injectable } from './../../utility/injectable';

export class ShiftDetailsController extends Injectable {
    static get $inject() {
        return ['$timeout', 'TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.shiftScheduleApi = this.TglApiInterfaceFactory.createApiInterface('shiftSchedule');

        this.shift = {};
        this.loading = true;
        this.showLoadingCompleted = false;
        this.$timeout(() => {
            this.showLoadingCompleted = true;
        }, 1000);

        var self = this;
        this.shiftScheduleApi.get(this.shiftScheduleId, { model: this.shift })
            .then(() => self.loading = false);
    }

    isContentReady() {
        return !this.loading && this.showLoadingCompleted;
    }

    getShiftEndTime(shift) {
        return moment(shift.fromDate).add(shift.durationMinutes, 'minutes');
    }
}