import { componentFactory } from './../../utility/component-factory';

import { ProfessionalityFormController } from './professionality-form-controller';

import { commonServices } from './../../common/common-services';
import { jobTagSearch } from './../job-tag-search/job-tag-search';

export let professionalityForm = componentFactory(
    'professionalityForm',
    ProfessionalityFormController,
    [commonServices, jobTagSearch]);