(function () {
    angular.module('app', ['ui.router', 'ui.bootstrap', 'LocalStorageModule'])
        .config(['$stateProvider', '$locationProvider', function ($stateProvider, $locationProvider) {
            // UI States, URL Routing & Mapping. For more info see: https://github.com/angular-ui/ui-router
            // ------------------------------------------------------------------------------------------------------------
            //  Configured, AS NEEDED, inside of their Angular directory:
            //  controllers
            //  directives
            //  services
            //  views
            // ------------------------------------------------------------------------------------------------------------

            $stateProvider
            .state('dashboard', {
                url: '/',
                templateUrl: '/Angular/dashboard/views/dashboard.html',
                data: {
                    Authorize: "Anonymous"
                }

            })

            .state('about', {
                url: '/about',
                templateUrl: '/Angular/about/views/about.html',
                data: {
                    Authorize: "All"
                }

            })

            .state('accounts', {
                url: '/accounts',
                templateUrl: '/Angular/accounts/views/accounts.html',
                abstract: true
            })

            .state('accounts.overview', {
                url: '/',
                templateUrl: '/Angular/accounts/views/accounts.overview.html',
            })


            .state('accounts.edit', {
                url: '/edit',
                templateUrl: '/Angular/accounts/views/accounts.edit.html',
            })

            .state('account.transactions', {
                url: 'accounts/:accountId/transactions',
                templateUrl: '/Angular/accounts/views/accounts.transactions.html',
            })           

            .state('budgets', {
                url: '/budgets',
                templateUrl: '/Angular/budgets/views/budgets.html',

            })

            .state('households', {
                url: '/households',
                templateUrl: '/Angular/households/views/households.html',

            })

            .state('users', {
                url: '/users',
                templateUrl: '/Angular/users/views/users.html',

            })

            //not properly configured, according to Thomas
            //$locationProvider.html5Mode({
            //    enabled: true,
            //    requireBase: false
            //});


        }])

    // Gets executed after the injector is created and are used to kickstart the application. Only instances and constants
    // can be injected here. This is to prevent further system configuration during application run time.
    .run(['$templateCache', '$rootScope', '$state', '$stateParams', function ($templateCache, $rootScope, $state, $stateParams) {
        // Allows to retrieve UI Router state information from inside templates
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;

    }]);
})();