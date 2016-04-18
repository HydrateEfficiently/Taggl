import { componentFactory } from './../../utility/component-factory';

import { ShiftFormController } from './shift-form-controller';

import { commonServices } from './../../common/common-services';

export let shiftForm = componentFactory(
    'shiftForm',
    ShiftFormController,
    [commonServices],
    { saveShift: '&' });