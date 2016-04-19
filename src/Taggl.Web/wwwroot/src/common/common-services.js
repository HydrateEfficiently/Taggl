import * as angular from 'angular';

import { HttpService } from './services/http-service';
import { UrlService } from './services/url-service';
import { SessionService } from './services/session-service';
import { LoggingService } from './services/logging-service';
import { ApiInterfaceFactory } from './services/api-interface-factory';

let commonServices = angular.module('tgl.common.services', [])
    .service('TglHttpService', HttpService)
    .service('TglUrlService', UrlService)
    .service('TglSessionService', SessionService)
    .service('TglLoggingService', LoggingService)
    .service('TglApiInterfaceFactory', ApiInterfaceFactory)
    .name;

export { commonServices };