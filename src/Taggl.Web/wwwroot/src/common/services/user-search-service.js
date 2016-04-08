import { Injectable } from './../../utility/injectable';

export class UserSearchService extends Injectable {
    static get $inject() {
        return ['TglUrlService', 'TglHttpService'];
    }

    constructor(...deps) {
        super(...deps);
    }

    search(pattern, options = {}) {
        let url = this.AznUrlService.getUrl('api.search.users', pattern);
        return this.TglHttpService.get(url, 1000).then(result => result.data);
    }
}