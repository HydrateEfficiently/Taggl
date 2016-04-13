import { Injectable } from './../../utility/injectable';

export class SessionService extends Injectable {
    static get $inject() {
        return ['$window', 'TglHttpService', 'TglUrlService', 'TglServerData'];
    }

    constructor(...deps) {
        super(...deps);

        this.user = angular.copy(this.TglServerData.user);
    }

    getUser() {
        return this.user;
    }

    updateUser(user) {
        
    }

    onUserUpdated(listener) {

    }

    isAdministrator() {
        return true; // TODO:
    }

    logout() {
        let { $window, TglUrlService, TglHttpService } = this;
        let logOffUrl = TglUrlService.getUrl('api.account.logout');
        return TglHttpService.post(logOffUrl).then(() => 
            $window.location.href = TglUrlService.getUrl('home.index'));
    }
}