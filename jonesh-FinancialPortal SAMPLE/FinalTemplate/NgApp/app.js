/// <reference path="Views/Accounts.html" />
/// <reference path="Views/Accounts.html" />
/// <reference path="Services/authServices.js" />
(function () {
    var app = angular.module('app', ['ui.router', 'LocalStorageModule', 'ui.bootstrap', 'ngSanitize','ui.select'])
        .run(['$rootScope', '$state', '$stateParams', '$http', '$interval', 'authSvc',
              function ($rootScope, $state, $stateParams, $http, $interval, authSvc) {
                  //OnLoad goes here if needed
                  $rootScope.$state = $state;
                  $rootScope.$stateParams = $stateParams;

                  //authSvc.fillAuthData();

                  //// Just for testing 
                  //var login = { username: "admin@coderfoundry.com", password: "Password-1" };



                  ////var user = {
                  ////    UserName: "admin@coderfoundry.com",
                  ////    Name: "Johnny",
                  ////    Password: "Password-1",
                  ////    ConfirmedPassword: "Password-1",
                  ////    Email: "admin@coderfoundry.com"
                  ////};

                  ////authSvc.register(user);


                  //authSvc.login(login);
                  ////authSvc.logOut();
              }])
        .config(['$stateProvider', '$urlRouterProvider', '$httpProvider','uiSelectConfig',
                 function ($stateProvider, $urlRouterProvider, $httpProvider, uiSelectConfig) {
                     uiSelectConfig.theme = 'select2';
                     //$httpProvider.interceptors.push('httpRequestInterceptor');
                     $httpProvider.interceptors.push('authInterceptorSvc');

                     // Use $urlRouterProvider to configure any redirects (when) and invalid urls (otherwise).
                     $urlRouterProvider
                       // The `when` method says if the url is ever the 1st param, then redirect to the 2nd param
                       // Here we are just setting up some convenience urls.
                       //.when('/', '/')
                       // If the url is ever invalid, e.g. '/asdf', then redirect to '/' aka the home state
                        .when('about', '/about')
                        .otherwise('/');

                     // Use $stateProvider to configure your states.
                     $stateProvider
                       .state("Home", {
                           // Use a url of "/" to set a states as the "index".
                           url: "/",
                           templateUrl: 'NgApp/Views/Home.html',
                           controller: 'HomeCtrl'
                       })
                       .state("home.child", {

                           // Use a url of "/" to set a states as the "index".
                           url: "child",
                           templateUrl: 'NgApp/Views/Home/home.child.html'
                       })
                       .state("Accounts", {
                           url: "/Accounts",
                           templateUrl: 'NgApp/Views/Accounts/Accounts.html',
                           controller: 'AccountsCtrl'
                       })
                         .state("Transactions", {
                             url: "/:accountId/Transactions",
                             templateUrl: 'NgApp/Views/Transactions/Transactions.html',
                             controller: 'TransactionsCtrl'
                         })
                         .state("Budget", {
                             url: "/Budget",
                             templateUrl: 'NgApp/Views/Budget/Budget.html',
                             controller: 'BudgetCtrl'
                         })
                         .state("User", {
                             url: "/User",
                             templateUrl: 'NgApp/Views/User/User.html',
                             controller: 'UserCtrl'
                         })
                        .state("Household", {
                            url: "/Household",
                            templateUrl: 'NgApp/Views/Household/Household.html',
                            controller: 'HouseholdCtrl'
                        })

                     $httpProvider.defaults.withCredentials = true;
                     $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
                 }]);





})();