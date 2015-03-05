(function () {
    angular.module('app', ['ui.router', 'ui.bootstrap', 'LocalStorageModule'])
        .config(['$stateProvider', '$locationProvider', function ($stateProvider, $locationProvider) {
            // UI States, URL Routing & Mapping. For more info see: https://github.com/angular-ui/ui-router
            // ------------------------------------------------------------------------------------------------------------

            $stateProvider
                .state('dashboard', {
                    url: '/',
                    templateUrl: '/Angular/dashboard/views/dashboard.html',

                })

            $locationProvider.html5Mode({
                enabled: true,
                requireBase: false
            });


        }])

    // Gets executed after the injector is created and are used to kickstart the application. Only instances and constants
    // can be injected here. This is to prevent further system configuration during application run time.
    .run(['$templateCache', '$rootScope', '$state', '$stateParams', function ($templateCache, $rootScope, $state, $stateParams) {
        // Allows to retrieve UI Router state information from inside templates
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;

    }]);
})();