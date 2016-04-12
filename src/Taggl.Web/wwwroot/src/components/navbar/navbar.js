import { componentFactory } from './../../utility/component-factory';

import { NavbarController } from './navbar-controller';

import { commonServices } from './../../common/common-services';
import dropdown from 'angular-ui-bootstrap/src/dropdown/index-nocss';
import 'angular-ui-bootstrap/src/position/position.css!';


export let navbar = componentFactory(
    'navbar',
    NavbarController,
    [commonServices, dropdown]);