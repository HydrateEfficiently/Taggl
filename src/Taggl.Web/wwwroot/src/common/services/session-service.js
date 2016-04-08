import { Injectable } from './../../utility/injectable';

export class SessionService extends Injectable {
    static get $inject() {
        return ['$window', 'TglHttpService', 'TglUrlService', 'TglServerData'];
    }

    constructor(...deps) {
        super(...deps);
    }

    getUser() {
        return this.TglServerData.user;
    }

    logout() {
        let { $window, TglUrlService, TglHttpService } = this;
        let logOffUrl = TglUrlService.getUrl('api.account.logout');
        return TglHttpService.post(logOffUrl).then(() => 
            $window.location.href = TglUrlService.getUrl('home.index'));

        
        // var success = () => this.$window.location.href = urls.home.landing;
        // var error = () => this.ErrorService.post("Failed to log off!");
        // return this.$http.post(urls.account.logOff).then(
        //     success.bind(this),
        //     error.bind(this));
    }
}