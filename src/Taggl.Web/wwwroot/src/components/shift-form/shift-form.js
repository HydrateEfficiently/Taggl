import { componentFactory } from './../../utility/component-factory';

import { ShiftFormController } from './shift-form-controller';

import { commonServices } from './../../common/common-services';
import { commonFilters } from './../../common/common-filters';
import { search } from './../search/search';

export let shiftForm = componentFactory(
    'shiftForm',
    ShiftFormController,
    [commonServices, commonFilters, search],
    {
        shiftScheduleId: '@',
        date: '=',
        onSave: '&',
        onCancel: '&'
    });