import { modalBaseDirective } from './directives/modal-base/modal-base-directive';

function onEnter() {
    return (scope, element, attrs) => 
        element.bind("keydown keypress", event => {
            if (event.which === 13) {
                scope.$apply(() => scope.$eval(attrs.tglOnEnter, { value: element.val() }));
                event.stopImmediatePropagation();
            }
        });
}

let commonDirectives = angular.module('tgl.common.directives', [])
    .directive('tglModalBaseDirective', modalBaseDirective)
    .directive('tglOnEnter', onEnter)
    .name;

export { commonDirectives };