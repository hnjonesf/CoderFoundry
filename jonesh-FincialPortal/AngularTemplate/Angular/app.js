var app = angular.module('app', ['ui.router', 'ui.bootstrap', 'LocalStorageModule']);


app.config(['$stateProvider', '$locationProvider', function ($stateProvider, $locationProvider) {
    // UI States, URL Routing & Mapping. For more info see: https://github.com/angular-ui/ui-router
    // ------------------------------------------------------------------------------------------------------------
    //  Configured, AS NEEDED, inside of their Angular directory:
    //  controllers
    //  directives
    //  services
    //  views
    // ------------------------------------------------------------------------------------------------------------

    $stateProvider
    .state('Dashboard', {
        url: '/',
        templateUrl: '/Angular/dashboard/views/dashboard.html',
        data: {
            Authorize: "All"
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
        url: '/Accounts',
        templateUrl: '/Angular/accounts/views/accounts.html',
        abstract: true
    })

    .state('Accounts.Overview', {
        url: '/',
        templateUrl: '/Angular/accounts/views/accounts.overview.html',
        data: {
            Authorize: "All"
        }
    })


    .state('Accounts.Edit', {
        url: '/edit',
        templateUrl: '/Angular/accounts/views/accounts.edit.html',
        data: {
            Authorize: "All"
        }
    })

    .state('Account.Transactions', {
        url: 'accounts/:accountId/transactions',
        templateUrl: '/Angular/accounts/views/accounts.transactions.html',
        data: {
            Authorize: "All"
        }
    })

    .state('Budgets', {
        url: '/budgets',
        templateUrl: '/Angular/budgets/views/budgets.html',
        data: {
            Authorize: "All"
        }

    })

    .state('Households', {
        url: '/households',
        templateUrl: '/Angular/households/views/households.html',
        data: {
            Authorize: "All"
        }

    })

    .state('Login', {
        url: '/login',
        templateUrl: '/Angular/users/views/login.html',
        data: {
            Authorize: "Anonymous"
        }

    })

    .state('Register', {
        url: '/register',
        templateUrl: '/Angular/users/views/register.html',
        data: {
            Authorize: "Anonymous"
        }

    })

    $locationProvider.html5Mode({
        enabled: false,
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