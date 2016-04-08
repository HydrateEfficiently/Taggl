import { MainController } from './main-controller';
import { config } from './config';

import { commonServices } from './../../common/common-services';
import { commonFilters } from './../../common/common-filters';

import { profile } from './../../components/profile/profile';

let app = angular.module('tgl.main.app', [
    'ui.router',
    
    commonServices,
    commonFilters,

    profile
])
.controller('MainController', MainController);

import { appRunnerFactory } from './../../utility/app-runner-factory';
let run = appRunnerFactory(app, config);
export { run };