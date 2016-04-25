import { componentFactory } from './../../utility/component-factory';

import { DayScheduleController } from './day-schedule-controller';

import { commonServices } from './../../common/common-services';
import { commonFilters } from './../../common/common-filters';
import { search } from './../search/search';
import { shift } from './../shift/shift';

export let daySchedule = componentFactory(
    'daySchedule',
    DayScheduleController,
    [commonServices, commonFilters, search, shift],
    {
        timestamp: '@'
    });