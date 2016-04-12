import { componentFactory } from './../../utility/component-factory';

import { PersonalInformationController } from './personal-information-controller';

import { commonServices } from './../../common/common-services';

export let personalInformation = componentFactory(
    'personalInformation',
    PersonalInformationController,
    [commonServices],
    {
        bindToController: {
            'initialModelJson': '@',
            'onModelChanged': '&'
        }
    });