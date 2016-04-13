import { componentFactory } from './../../utility/component-factory';

import { SettingsController } from './settings-controller';

import { commonServices } from './../../common/common-services';
import { personalInformation } from './../personal-information/personal-information';
import { professionalityForm } from './../professionality-form/professionality-form';

export let settings = componentFactory(
    'settings',
    SettingsController,
    [commonServices, personalInformation, professionalityForm]);