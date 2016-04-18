export function modalStateLoader(title, templateName, modalButtons = '', closeEvent = 'no-close-event') {
    return ($stateParams, $state, $uibModal) => {
        $uibModal.open({
            template: `
                <tgl-modal-base-directive modal-title="${title}">
                    <${templateName} ${closeEvent}="dismiss()"></${templateName}>
                </tgl-modal-base-directive>`,
            // resolve: {
            //   item: function() { new Item(123).get(); }
            // },
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