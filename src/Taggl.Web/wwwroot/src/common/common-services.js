import { UserSearchService } from './services/user-search-service';
import { HttpService } from './services/http-service';
import { UrlService } from './services/url-service';
import { SessionService } from './services/session-service';
import { LoggingService } from './services/logging-service';

let commonServices = angular.module('tgl.common.services', [])
    .service('TglUserSearchService', UserSearchService)
    .service('TglHttpService', HttpService)
    .service('TglUrlService', UrlService)
    .service('TglSessionService', SessionService)
    .service('TglLoggingService', LoggingService)
    .name;

export { commonServices };