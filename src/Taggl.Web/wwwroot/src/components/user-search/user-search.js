import { componentFactory } from './../../utility/component-factory';

import { UserSearchController } from './user-search-controller';

import { commonServices } from './../../common/common-services';
import typeahead from 'angular-ui-bootstrap/src/typeahead/index-nocss';
import 'angular-ui-bootstrap/src/typeahead/typeahead.css!';

export let userSearch = componentFactory(
    'userSearch',
    UserSearchController,
    [commonServices, typeahead],
    {
        bindToController: {
            initialUser: '@',
            onUserChanged: '&'
        }
    });