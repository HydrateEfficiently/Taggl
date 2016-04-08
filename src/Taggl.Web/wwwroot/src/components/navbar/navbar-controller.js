import { Injectable } from './../../utility/injectable';

export class NavbarController extends Injectable {
    static get $inject() {
        return ['TglSessionService'];
    }

    constructor(...deps) {
        super(...deps);

        this.userName = this.TglSessionService.getUser().email;
    }

    logout() {
        this.TglSessionService.logout();
    }
}