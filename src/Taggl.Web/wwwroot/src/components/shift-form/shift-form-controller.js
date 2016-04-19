import { Injectable } from './../../utility/injectable';
import { SearchSource } from './../search/search';

export class ShiftFormController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);

        this.shift = {};
        this.searchSource = SearchSource.ShiftTypes;
        // let self = this;
        // this.$timeout(this.saveShift, 5000);
    }

    selectShiftType(shiftType) {
        this.shift.shiftType = shiftType;
    }
}