var app = angular.module('app', ['ui.router', 'ui.bootstrap', 'LocalStorageModule']);


app.config(['$stateProvider', '$locationProvider', '$httpProvider', '$urlRouterProvider', function 
($stateProvider, $locationProvider, $httpProvider, $urlRouterProvider) {
    // UI States, URL Routing & Mapping. For more info see: https://github.com/angular-ui/ui-router
    // ------------------------------------------------------------------------------------------------------------

    $urlRouterProvider
    .otherwise('/');

    // -------------------------------------------------------------------------------------------------------
    //  Configured, AS NEEDED, inside of their Angular directory:
    //  controllers
    //  directives
    //  services
    //  views
    // ------------------------------------------------------------------------------------------------------------


    $stateProvider

        ///ABOUT
    .state('About', {
        url: '/About',
        templateUrl: '/Angular/about/views/about.overview.html',
        data: {
            Authorize: "Anonymous"
        }

    })
        ///ACCOUNTS
    .state('Accounts', {
        url: '/Accounts',
        templateUrl: '/Angular/accounts/views/Accounts.html',
        data: {
            Authorize: "All"
        }
        //abstract: true
    })

    .state('CreateAccount', {
        url: '/CreateAccount',
        templateUrl: '/Angular/accounts/views/CreateAccount.html',
        data: {
            Authorize: "All"
        }
        //abstract: true
    })

    .state('EditAccount', {
        url: '/EditAccount/:id',
        templateUrl: '/Angular/accounts/views/EditAccount.html',
        data: {
            Authorize: "All"
        },
        controller: 'EditAccountController',
        resolve: {
            account: ['$stateParams', 'accountsService', function ($stateParams, accountsService) {
                return accountsService.getAccount($stateParams.id)
                .then(function (data) { return data; });
            }]
        }
        //abstract: true
    })

    .state('DeleteAccount', {
        url: '/DeleteAccount/:id',
        templateUrl: '/Angular/accounts/views/DeleteAccount.html',
        data: {
            Authorize: "All"
        },
        controller: 'DeleteAccountController',
        resolve: {
            account: ['$stateParams', 'accountsService', function ($stateParams, accountsService) {
                return accountsService.deleteAccount($stateParams.id)
                .then(function (data) { return data; });
            }]
        }
        //abstract: true
    })


      ///BUDGETS
    .state('Budgets', {
        url: '/Budgets',
        templateUrl: '/Angular/budgets/views/Budgets.html',
        data: {
            Authorize: "All"
        }
        //abstract: true
    })

    .state('CreateBudget', {
        url: '/CreateBudget',
        templateUrl: '/Angular/budgets/views/CreateBudget.html',
        data: {
            Authorize: "All"
        }
        //abstract: true
    })

    .state('EditBudget', {
        url: '/EditBudget/:id',
        templateUrl: '/Angular/budgets/views/EditBudget.html',
        data: {
            Authorize: "All"
        },
        controller: 'EditBudgetController',
        resolve: {
            account: ['$stateParams', 'budgetsService', function ($stateParams, budgetsService) {
                return budgetsService.getBudget($stateParams.id)
                .then(function (data) { return data; });
            }]
        }
        //abstract: true
    })

    .state('DeleteBudget', {
        url: '/DeleteBudget/:id',
        templateUrl: '/Angular/budgets/views/BudgetAccount.html',
        data: {
            Authorize: "All"
        },
        controller: 'DeleteBudgetController',
        resolve: {
            account: ['$stateParams', 'budgetsService', function ($stateParams, budgetsService) {
                return budgetsService.deleteBudget($stateParams.id)
                .then(function (data) { return data; });
            }]
        }
        //abstract: true
    })
        ///CATEGORIES
       ///ACCOUNTS
    .state('Categories', {
        url: '/Categories',
        templateUrl: '/Angular/categories/views/Categories.html',
        data: {
            Authorize: "All"
        }
        //abstract: true
    })

    .state('CreateCategory', {
        url: '/CreateCategory',
        templateUrl: '/Angular/categories/views/CreateCategory.html',
        data: {
            Authorize: "All"
        }
        //abstract: true
    })

    .state('EditCategory', {
        url: '/EditCategory/:id',
        templateUrl: '/Angular/categories/views/EditCategory.html',
        data: {
            Authorize: "All"
        },
        controller: 'EditCategoryController',
        resolve: {
            account: ['$stateParams', 'categoriesService', function ($stateParams, categoriesService) {
                return categoriesService.getCategory($stateParams.id)
                .then(function (data) { return data; });
            }]
        }
        //abstract: true
    })

    .state('DeleteCategory', {
        url: '/DeleteCategory/:id',
        templateUrl: '/Angular/categories/views/DeleteCategory.html',
        data: {
            Authorize: "All"
        },
        controller: 'DeleteCategoryController',
        resolve: {
            account: ['$stateParams', 'categoriesService', function ($stateParams, categoriesService) {
                return categoriesService.deleteCategory($stateParams.id)
                .then(function (data) { return data; });
            }]
        }
        //abstract: true
    })
        ///DASHBOARD***Homer template
    .state('Dashboard', {
        url: '/',
        templateUrl: '/Angular/dashboard/views/dashboard.html',
        data: {
            Authorize: "All"
        }
    })



              ///TRANSACTIONS
    .state('Transactions', {
        url: '/Transactions',
        templateUrl: '/Angular/transactions/views/Transactions.html',
        data: {
            Authorize: "All"
        }
        //abstract: true
    })

    .state('CreateTransaction', {
        url: '/CreateTransaction',
        templateUrl: '/Angular/transactions/views/CreateTransaction.html',
        data: {
            Authorize: "All"
        }
        //abstract: true
    })

    .state('EditTransaction', {
        url: '/EditTransaction/:id',
        templateUrl: '/Angular/transactions/views/EditTransaction.html',
        data: {
            Authorize: "All"
        },
        controller: 'EditTransactionController',
        resolve: {
            account: ['$stateParams', 'transactionsService', function ($stateParams, transactionsService) {
                return transactionsService.getTransaction($stateParams.id)
                .then(function (data) { return data; });
            }]
        }
        //abstract: true
    })

    .state('DeleteTransaction', {
        url: '/DeleteTransaction/:id',
        templateUrl: '/Angular/transactions/views/DeleteTransaction.html',
        data: {
            Authorize: "All"
        },
        controller: 'DeleteTransactionController',
        resolve: {
            account: ['$stateParams', 'transactionsService', function ($stateParams, transactionsService) {
                return transactionsService.deleteTransaction($stateParams.id)
                .then(function (data) { return data; });
            }]
        }
        //abstract: true
    })

        ///USERS

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

    //$locationProvider.html5Mode({
    //    enabled: false,
    //    requireBase: false
    //});


}])

// Gets executed after the injector is created and are used to kickstart the application. Only instances and constants
// can be injected here. This is to prevent further system configuration during application run time.
.run(['$templateCache', '$rootScope', '$state', '$stateParams', 'authService', function ($templateCache, $rootScope, $state, $stateParams, authService) {
    // Allows to retrieve UI Router state information from inside templates
    $rootScope.$state = $state;
    $rootScope.$stateParams = $stateParams;

    authService.fillAuthData();

    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
        //For later improved security
        var authorized = false;

        if (toState.data.Authorize.indexOf("Anonymous") > -1)
            authorized = true
        else {
            if (authService.authentication.isAuth) {

                if (toState.data.Authorize.indexOf("All") > -1)
                    authorized = true;
                else {
                    angular.forEach(authService.authentication.Roles, function (value, key) {
                        if (toState.Authorize.data.indexOf(value))
                            authorized = true;
                    });
                }
            }
        }
        if (authorized == false) {
            event.preventDefault();
            authService.logOut();
            $state.go('Login');
        }
    });


}]);