import { MainController } from './main-controller';
import { config } from './config';

import { commonServices } from './../../common/common-services';
import { commonFilters } from './../../common/common-filters';

import { navbar } from './../../components/navbar/navbar';
import { profile } from './../../components/profile/profile';
import { administration } from './../../components/administration/administration';
import { settings } from './../../components/settings/settings';
import { calendarMain } from './../../components/calendar-main/calendar-main';

let app = angular.module('tgl.main.app', [
    'ui.router',
    
    commonServices,
    commonFilters,

    navbar,
    profile,
    administration,
    settings,
    calendarMain
])
.controller('MainController', MainController);

import { appRunnerFactory } from './../../utility/app-runner-factory';
let run = appRunnerFactory(app, config);
export { run };