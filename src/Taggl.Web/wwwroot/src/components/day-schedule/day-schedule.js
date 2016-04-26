import { componentFactory } from './../../utility/component-factory';

import { DayScheduleController } from './day-schedule-controller';

import { commonServices } from './../../common/common-services';
import { commonFilters } from './../../common/common-filters';
import { search } from './../search/search';
import { shiftDetails } from './../shift-details/shift-details';

export let daySchedule = componentFactory(
    'daySchedule',
    DayScheduleController,
    [commonServices, commonFilters, search, shiftDetails],
    {
        timestamp: '@'
    });