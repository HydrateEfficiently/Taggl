'use strict';

import '/assets/scss/css/shift-details.css!';
import '/assets/scss/css/actions-bar.css!';

import { componentFactory } from './../../utility/component-factory';
import { ShiftDetailsController } from './shift-details-controller';

import { commonServices } from './../../common/common-services';
import { commonFilters } from './../../common/common-filters';
import { commonDirectives } from './../../common/common-directives';
import { shiftForm } from './../shift-form/shift-form';
import { shiftComments } from './../shift-comments/shift-comments';

export let shiftDetails = componentFactory(
    'shiftDetails',
    ShiftDetailsController,
    [commonServices, commonFilters, commonDirectives, shiftForm, shiftComments],
    {
        shiftScheduleId: '@'
    });