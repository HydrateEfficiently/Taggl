import { componentFactory } from './../../utility/component-factory';

import { CalendarController } from './calendar-controller';

import { commonServices } from './../../common/common-services';
import datepicker from 'angular-ui-bootstrap/src/datepicker/index-nocss';
import 'angular-ui-bootstrap/src/datepicker/datepicker.css!';

export let calendar = componentFactory(
    'calendar',
    CalendarController,
    [commonServices, datepicker],
    { onDateSelected: '&' });