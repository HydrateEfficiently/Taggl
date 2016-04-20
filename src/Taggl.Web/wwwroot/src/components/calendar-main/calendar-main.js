import { componentFactory } from './../../utility/component-factory';

import { CalendarMainController } from './calendar-main-controller';

import { commonServices } from './../../common/common-services';
import { commonFilters } from './../../common/common-filters';
import { modal } from '/imports/angular-ui-bootstrap@1.3.1/modal.js';
import { shiftForm } from './../shift-form/shift-form';
import { calendar } from './../calendar/calendar';
import { daySchedule } from './../day-schedule/day-schedule';

export let calendarMain = componentFactory(
    'calendarMain',
    CalendarMainController,
    [commonServices, commonFilters, modal, shiftForm, calendar, daySchedule]);