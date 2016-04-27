'use strict';

import '/assets/scss/css/components/shift-comments.css!';

import { componentFactory } from './../../utility/component-factory';
import { ShiftCommentsController } from './shift-comments-controller';

import { commonServices } from './../../common/common-services';
import { userAvatar } from './../user-avatar/user-avatar';

export let shiftComments = componentFactory(
    'shiftComments',
    ShiftCommentsController,
    [commonServices, userAvatar]);