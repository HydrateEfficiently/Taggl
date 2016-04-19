import { componentFactory } from './../../utility/component-factory';

import { CalendarController } from './calendar-controller';

import { commonServices } from './../../common/common-services';
import { commonFilters } from './../../common/common-filters';
import 'angular-bootstrap-calendar/dist/js/angular-bootstrap-calendar-tpls.js';
import 'angular-bootstrap-calendar/dist/css/angular-bootstrap-calendar.min.css!';

export let calendar = componentFactory(
    'calendar',
    CalendarController,
    [commonServices, commonFilters, 'mwl.calendar'],
    {
        month: '='
    });