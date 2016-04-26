import { Injectable } from './../../utility/injectable';
import { SearchSource } from './../search/search';

export class CreateShiftController extends Injectable {
    static get $inject() {
        return ['$uibModalInstance', 'date'];
    }

    constructor(...deps) {
        super(...deps);
    }

    closeModal(result) {
        this.$uibModalInstance.close(result);
    }
}