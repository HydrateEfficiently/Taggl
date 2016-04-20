export function modalLoader2(title, templateName, ...closeEvents) {
    return ($stateParams, $state, $uibModal) => {
        let closeEventHtml = closeEvents
            .map(closeEvent => `${closeEvent}="dismiss()"`)
            .join(' ');
        $uibModal.open({
            template: `
                <tgl-modal-base-directive modal-title="${title}">
                    <${templateName} ${closeEventHtml}></${templateName}>
                </tgl-modal-base-directive>`,
            controller: ['$scope', function($scope) {
                $scope.dismiss = function() {
                    $scope.$dismiss();
                };
            }]
        }).result.finally(function() {
            $state.go('^');
        });
    };
}