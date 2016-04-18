import { componentFactory } from './../../utility/component-factory';

import { ProfessionalityFormController } from './professionality-form-controller';

import { commonServices } from './../../common/common-services';
import { search } from './../search/search';

export let professionalityForm = componentFactory(
    'professionalityForm',
    ProfessionalityFormController,
    [commonServices, search]);