import { Injectable } from './../../utility/injectable';

export class MainController extends Injectable {
    static get $inject() {
        return [];
    }

    constructor(...deps) {
        super(...deps);

        this.message = 'hi from main!';
    }

}