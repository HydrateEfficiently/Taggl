import { componentFactory } from './../../utility/component-factory';

import { ShiftDetailsController } from './shift-details-controller';

import { commonServices } from './../../common/common-services';
import { commonFilters } from './../../common/common-filters';

import { shiftComments } from './../shift-comments/shift-comments';

import '/assets/scss/css/shift-details.css!';
import '/assets/scss/css/actions-bar.css!';

export let shiftDetails = componentFactory(
    'shiftDetails',
    ShiftDetailsController,
    [commonServices, commonFilters, shiftComments],
    {
        shiftScheduleId: '@'
    });