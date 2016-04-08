import { componentFactory } from './../../utility/component-factory';
import { NavbarController } from './navbar-controller';
import { commonServices } from './../../common/common-services';

export let navbar = componentFactory(
    'navbar',
    NavbarController,
    [commonServices]);