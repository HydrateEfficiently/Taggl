export function modalBaseDirective() {
    return {
        scope: {
            modalTitle: '@'
        },
        transclude: true,
        templateUrl: 'src/common/directives/modal-base/modal-base.html'
    };
}