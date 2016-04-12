import { componentFactory } from './../../utility/component-factory';

import { ProfessionalInformationController } from './professional-information-controller';

import { commonServices } from './../../common/common-services';

export let professionalInformation = componentFactory(
    'professionalInformation',
    ProfessionalInformationController,
    [commonServices]);