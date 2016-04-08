import { componentFactory } from './../../utility/component-factory';
import { ProfileController } from './profile-controller';
import { commonServices } from './../../common/common-services';

export let profile = componentFactory(
    'profile',
    ProfileController,
    [commonServices]);