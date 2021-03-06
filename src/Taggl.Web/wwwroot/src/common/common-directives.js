import * as angular from 'angular';

import { modalBaseDirective } from './directives/modal-base/modal-base-directive';

function onEnter() {
    return (scope, element, attrs) => 
        element.bind("keydown keypress", event => {
            if (event.which === 13) {
                event.stopImmediatePropagation();
                scope.$apply(() => scope.$eval(attrs.tglOnEnter, { value: element.val() }));
            }
        });
}

let commonDirectives = angular.module('tgl.common.directives', [])
    .directive('tglModalBaseDirective', modalBaseDirective)
    .directive('tglOnEnter', onEnter)
    .name;

export { commonDirectives };