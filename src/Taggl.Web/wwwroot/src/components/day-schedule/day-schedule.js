import { componentFactory } from './../../utility/component-factory';

import { DayScheduleController } from './day-schedule-controller';

import { commonServices } from './../../common/common-services';
import { commonFilters } from './../../common/common-filters';
import { commonDirectives } from './../../common/common-directives';
import { shiftDetails } from './../shift-details/shift-details';
import { shiftForm } from './../shift-form/shift-form';

export let daySchedule = componentFactory(
    'daySchedule',
    DayScheduleController,
    [commonServices, commonFilters, commonDirectives, shiftDetails, shiftForm],
    {
        timestamp: '@'
    });