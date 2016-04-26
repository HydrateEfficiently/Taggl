import { componentFactory } from './../../utility/component-factory';

import { ShiftCommentsController } from './shift-comments-controller';

import { commonServices } from './../../common/common-services';

export let shiftComments = componentFactory(
    'shiftComments',
    ShiftCommentsController,
    [commonServices]);