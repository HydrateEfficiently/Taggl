import { componentFactory } from './../../utility/component-factory';

import { CalendarMainController } from './calendar-main-controller';

import { commonServices } from './../../common/common-services';
import { modal } from '/imports/angular-ui-bootstrap@1.3.1/modal.js';
import { shiftForm } from './../shift-form/shift-form';

export let calendarMain = componentFactory(
    'calendarMain',
    CalendarMainController,
    [commonServices, modal, shiftForm]);