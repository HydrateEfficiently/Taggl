import { Injectable } from './../../utility/injectable';

export class ShiftController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.shiftScheduleApi = this.TglApiInterfaceFactory.createApiInterface('shiftSchedule');

        this.shift = {};
        this.shiftScheduleApi.get(this.shiftScheduleId, { model: this.shift });
    }

    getShiftEndTime(shift) {
        return moment(shift.date).add(shift.durationMinutes, 'minutes');
    }
}