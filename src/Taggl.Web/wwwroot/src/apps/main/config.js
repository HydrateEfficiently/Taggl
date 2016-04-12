export function config($stateProvider, $urlRouterProvider) {
    // TODO: Annotate injection
    $urlRouterProvider.otherwise('/profile');

    $stateProvider
        .state('profile', {
            url: '/profile',
            template: '<tgl-profile></tgl-profile>'
        })
        .state('administration', {
            url: '/administration',
            template: '<tgl-administration></tgl-administration>'
        })
        .state('settings', {
            url: '/settings',
            template: '<tgl-settings></tgl-settings>'
        });


        // .state('registry', {
        //     url: '/registry',
        //     template: '<registry-view></registry-view>',
        //     data: { pageTitle: 'Risk Registry' }
        // })

        // .state('people', {
        //     url: '/people',
        //     template: '<people-view></people-view>',
        //     data: { pageTitle: 'People' }
        // })
        // .state('people.userDetails', {
        //     url: '/user-details/:userId',
        //     template: (params) => {
        //         return `<user-details user-id="'${params.userId}'""></user-details>`;
        //     }
        // })
        // .state('people.inviteDetails', {
        //     url: '/invite-details/:inviteId',
        //     template: (params) => {
        //         return `<invite-details invitation-id="'${params.inviteId}'"></invite-details>`;
        //     }
        // })

        // .state('identify', {
        //     url: '/identify',
        //     template: '<identify-view></identify-view>'
        // })

        // .state('administration', {
        //     url: '/administration',
        //     template: '<administration-view></administration-view>'
        // });
}