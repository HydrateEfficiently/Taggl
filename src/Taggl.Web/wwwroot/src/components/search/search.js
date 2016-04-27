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
        'initialId': '=',
        'ngModel': '=',
        'searchSource': '=',
        'initialModelJson': '@',
        'onItemSelected': '&',
        'onItemCreated': '&', // onLabelAdded?
        'onResultsRetrieved': '&',
        'clearOnSelect': '@',
        'createResults': '@' // addLabels?
    });

export { search, SearchSource };