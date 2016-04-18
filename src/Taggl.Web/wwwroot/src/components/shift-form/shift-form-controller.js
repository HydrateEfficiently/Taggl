import { Injectable } from './../../utility/injectable';

export class ShiftFormController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);

        this.shift = {};
        // let self = this;
        // this.$timeout(this.saveShift, 5000);
    }

    selectShiftType(shiftType) {
        this.shift.shiftType = shiftType;
    }
}