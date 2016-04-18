import { componentFactory } from './../../utility/component-factory';

import { SearchController, SearchSource } from './search-controller';

import { commonServices } from './../../common/common-services';
import { commonDirectives } from './../../common/common-directives';
import typeahead from 'angular-ui-bootstrap/src/typeahead/index-nocss';
import 'angular-ui-bootstrap/src/typeahead/typeahead.css!';

let search = componentFactory(
    'search',
    SearchController,
    [commonServices, commonDirectives, typeahead],
    {
        'searchSource': '=',
        'initialModelJson': '@',
        'onItemSelected': '&',
        'onItemCreated': '&',
        'onResultsRetrieved': '&',
        'clearOnSelect': '@',
        'createResults': '@' 
    });

export { search, SearchSource };