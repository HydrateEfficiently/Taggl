'use strict';

import { Injectable } from './../../utility/injectable';

export class ShiftCommentsController extends Injectable {
    static get $inject() {
        return ['TglLoggingService'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);

        this.comments = [
            {
                user: {
                    id: '1',
                    displayName: 'MF'
                },
                text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.'
            }
        ];
    }
}