import { componentFactory } from './../../utility/component-factory';

import { ShiftController } from './shift-controller';

import { commonServices } from './../../common/common-services';
import { commonFilters } from './../../common/common-filters';

export let shift = componentFactory(
    'shift',
    ShiftController,
    [commonServices],
    {
        shiftScheduleId: '@'
    });