import { componentFactory } from './../../utility/component-factory';

import { JobTagSearchController } from './job-tag-search-controller';

import { commonServices } from './../../common/common-services';
import { commonDirectives } from './../../common/common-directives';
import typeahead from 'angular-ui-bootstrap/src/typeahead/index-nocss';
import 'angular-ui-bootstrap/src/typeahead/typeahead.css!';

export let jobTagSearch = componentFactory(
    'jobTagSearch',
    JobTagSearchController,
    [commonServices, commonDirectives, typeahead],
    {
        'initialModelJson': '@',
        'onItemSelected': '&',
        'onItemCreated': '&',
        'onResultsRetrieved': '&',
        'clearOnSelect': '@'
    });