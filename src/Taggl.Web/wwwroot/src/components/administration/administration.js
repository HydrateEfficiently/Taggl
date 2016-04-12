import { componentFactory } from './../../utility/component-factory';

import { AdministrationController } from './administration-controller';

import { commonServices } from './../../common/common-services';
import { commonFilters } from './../../common/common-filters';
import { userSearch } from './../user-search/user-search';

export let administration = componentFactory(
    'administration',
    AdministrationController,
    [commonServices, commonFilters, userSearch]);