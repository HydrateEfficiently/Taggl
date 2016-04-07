import { HttpCacheService } from './services/http-cache-service';
import { HttpService } from './services/http-service';
import { UrlService } from './services/url-service';

import { LoggerFactory } from './services/logger-factory';

let commonServices = angular.module('tgl.common.services', [])
    .service('TglHttpCacheService', HttpCacheService)
    .service('TglHttpService', HttpService)
    .service('TglUrlService', UrlService)
    .service('TglLoggerFactory', LoggerFactory)
    .name;

export { commonServices };