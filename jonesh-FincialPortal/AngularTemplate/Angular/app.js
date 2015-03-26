var app = angular.module('app', [

    'ui.router',
    'ui.bootstrap',
        'ui.router',                // Angular flexible routing
        'ngSanitize',               // Angular-sanitize
        'ui.bootstrap',             // AngularJS native directives for Bootstrap
        'angular-flot',             // Flot chart
        'angles',                   // Chart.js
        'angular-peity',            // Peity (small) charts
        'cgNotify',                 // Angular notify
        'angles',                   // Angular ChartJS
        'ngAnimate',                // Angular animations
        'ui.map',                   // Ui Map for Google maps
        'ui.calendar',              // UI Calendar
        'summernote',               // Summernote plugin
        'ngGrid',                   // Angular ng Grid
        'ui.tree',                  // Angular ui Tree
        'bm.bsTour',                // Angular bootstrap tour
        'datatables',               // Angular datatables plugin
        'xeditable',                // Angular-xeditable
        'ui.select',                 // AngularJS ui-select
        'LocalStorageModule'
]);


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


      ///BUDGETS
    .state('Budgets', {
        url: '/Budgets',
        templateUrl: '/Angular/budgets/views/Budgets.html',
        data: {
            Authorize: "All"
        },
        //abstract: true
        controller: 'BudgetsController',
        resolve: {
            categories: [ 'authService','categoriesService', function (authService, categoriesService) {
                return categoriesService.getCategories(authService.authentication.houseHold);
            }],
            budgets: ['authService', 'budgetsService', function (authService, budgetsService) {
                return budgetsService.getBudgets(authService.authentication.houseHold);
            }]
        }
    })

    .state('CreateBudget', {
        url: '/CreateBudget',
        templateUrl: '/Angular/budgets/views/CreateBudget.html',
        data: {
            Authorize: "All"
        },
        controller: 'CreateBudgetController',
        resolve: {
            categories: ['authService', 'categoriesService', function (authService, categoriesService) {
                return categoriesService.getCategories(authService.authentication.houseHold);
            }]
        }
    })

    .state('EditBudget', {
        url: '/EditBudget/:id',
        templateUrl: '/Angular/budgets/views/EditBudget.html',
        data: {
            Authorize: "All"
        },
        controller: 'EditBudgetController',
        resolve: {
            budget: ['$stateParams', 'budgetsService', function ($stateParams, budgetsService) {
                return budgetsService.getBudget($stateParams.id)
                .then(function (data) { return data; });
            }],
            categories: ['authService', 'categoriesService', function (authService, categoriesService) {
                    return categoriesService.getCategories(authService.authentication.houseHold);
            }]
        }
    })



        ///CATEGORIES
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
        },
        controller: 'CreateCategoryController',
    })


    .state('EditCategory', {
        url: '/EditCategory/:id',
        templateUrl: '/Angular/categories/views/EditCategory.html',
        data: {
            Authorize: "All"
        },
        controller: 'EditCategoryController',
        resolve: {
            category: ['$stateParams', 'categoriesService', function ($stateParams, categoriesService) {
                return categoriesService.getCategory($stateParams.id)
                .then(function (data) { return data; });
            }]
        }
    })



        ///DASHBOARD***Homer template
    .state('Dashboard', {
        url: '/',
        templateUrl: '/Angular/dashboard/views/dashboard.html',
        data: {
            Authorize: "All"
        }
    })

                ///ACCOUNTS
    .state('Accounts', {
        url: '/Accounts',
        templateUrl: '/Angular/accounts/views/Accounts.html',
        data: {
            Authorize: "All"
        },
        abstract: true
    })

        .state('Accounts.List', {
            url: '/',
            templateUrl: '/Angular/accounts/views/Accounts.List.html',
            data: {
                Authorize: "All"
            }
        })

    .state('CreateAccount', {
        url: '/CreateAccount',
        templateUrl: '/Angular/accounts/views/CreateAccount.html',
        data: {
            Authorize: "All"
        }
    })

    .state('EditAccount', {
        url: '/EditAccount/{accountId}',
        templateUrl: '/Angular/accounts/views/EditAccount.html',
        data: {
            Authorize: "All"
        },
        controller: 'EditAccountController',
        resolve: {
            account: ['$stateParams', 'accountsService', function ($stateParams, accountsService) {
                return accountsService.getAccount($stateParams.accountId);
            }]
        }
    })


              ///TRANSACTIONS
    .state('Transactions', {
        url: '/Account/:accountId/Transactions/',
        templateUrl: '/Angular/transactions/views/Transactions.html',
        data: {
            Authorize: "All"
        },
        controller: 'TransactionsController',
        resolve: {
            categories: [ 'authService','categoriesService', function (authService, categoriesService) {
                return categoriesService.getCategories(authService.authentication.houseHold);
            }],
            transactions: ['$stateParams', 'accountsService', function ($stateParams, accountsService) {
                return accountsService.getTransactions($stateParams.accountId);
            }]
        }
    })

    .state('CreateTransaction', {
        url: '/Account/:accountId/CreateTransaction/',
        templateUrl: '/Angular/transactions/views/CreateTransaction.html',
        data: {
            Authorize: "All"
        },
        controller: 'CreateTransactionController',
        //GET CATEGORIES FOR HOUSEHOLD
        resolve: {
            categories: ['$stateParams', 'categoriesService', 'authService', function ($stateParams, categoriesService, authService) {
                return categoriesService.getCategories(authService.authentication.houseHold);
            }]
        }
    })

    .state('EditTransaction', {
        url: '/EditTransaction/:transactionId',
        templateUrl: '/Angular/transactions/views/EditTransaction.html',
        data: {
            Authorize: "All"
        },
        controller: 'EditTransactionController',
        //GET CATEGORIES FOR HOUSEHOLD, too
        resolve: {
            transaction: ['$stateParams', 'accountsService', function ($stateParams, accountsService) {
                return accountsService.getTransaction($stateParams.transactionId);        
            }],
            categories: ['$stateParams', 'categoriesService', 'authService', function ($stateParams, categoriesService, authService) {
                return categoriesService.getCategories(authService.authentication.houseHold);
            }]
        }
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
.run(['$templateCache', '$rootScope', '$state', '$stateParams', 'authService',  function ($templateCache, $rootScope, $state, $stateParams, authService) {
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