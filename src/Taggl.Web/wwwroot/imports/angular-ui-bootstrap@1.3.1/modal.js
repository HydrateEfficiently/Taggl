import 'angular-ui-bootstrap/src/stackedMap';
import 'angular-ui-bootstrap/template/modal/backdrop.html.js';
import 'angular-ui-bootstrap/template/modal/window.html.js';
import 'angular-ui-bootstrap/src/modal/modal';
import 'angular-ui-bootstrap/src/position/position.css!';

const MODULE_NAME = 'ui.bootstrap.module.modal';

angular.module(MODULE_NAME, ['ui.bootstrap.modal', 'uib/template/modal/backdrop.html', 'uib/template/modal/window.html']);

export let modal = MODULE_NAME;
