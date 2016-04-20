import { Injectable } from './../../utility/injectable';
import { SearchSource } from './../search/search';

export class AddShiftController extends Injectable {
    static get $inject() {
        return ['$uibModalInstance', 'day', 'TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);

        this.shift = {};
        this.searchSource = SearchSource.ShiftTypes;
    }

    selectShiftType(shiftType) {
        this.shift.shiftType = shiftType;
    }

    save() {
        debugger;
    }

    close() {
        this.$uibModalInstance.close();
    }
}