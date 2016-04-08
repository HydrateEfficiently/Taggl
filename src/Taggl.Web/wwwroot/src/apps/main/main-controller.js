import { Injectable } from './../../utility/injectable';

export class MainController extends Injectable {
    static get $inject() {
        return ['TglLoggingService'];
    }

    constructor(...deps) {
        super(...deps);

        this.TglLoggingService.logInitialized(this);
    }

}