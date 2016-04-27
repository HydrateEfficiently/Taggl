'use strict';

import { componentFactory } from './../../utility/component-factory';
import { UserAvatarController } from './user-avatar-controller';

import { commonServices } from './../../common/common-services';

export let userAvatar = componentFactory(
    'userAvatar',
    UserAvatarController,
    [commonServices],
    {
        userId: '@'
    });