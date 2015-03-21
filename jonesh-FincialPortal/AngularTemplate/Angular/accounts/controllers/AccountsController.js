angular.module('app')
.controller('AccountsController', ['$scope', '$state', '$stateParams', '$filter', 'accountsService', 'authService', 'ngTableParams',
    function ($scope, $state, $stateParams, $filter, accountsService, authService, ngTableParams) {

        //SETUP ACCOUNT TIES TO HOUSEHOLD
        $scope.houseHold = authService.authentication.houseHold;
        $scope.Name = "";
        $scope.Balance = "";
        $scope.ReconciledBalance = "";


        //get accounts
        $scope.getAccounts = function () {            
            accountsService.getAccounts($scope.houseHold).then(function (data) {
                $scope.accounts = data;

                //ng-Table Params
                $scope.tableParams = new ngTableParams({
                    page: 1,            // show first page
                    count: 10,          // count per page
                    filter: {
                        name: 'M'       // initial filter
                    },
                    sorting: {
                        name: 'asc'     // initial sorting
                    }
                }, {
                    total: data.length, // length of data
                    getData: function($defer, params) {
                        // use build-in angular filter
                        var filteredData = params.filter() ?
                                $filter('filter')(data, params.filter()) :
                                data;
                        var orderedData = params.sorting() ?
                                $filter('orderBy')(filteredData, params.orderBy()) :
                                data;

                        params.total(orderedData.length); // set total for recalc pagination
                        $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
                    }
                });
            });

        }


        //create account
        $scope.createAccount = function createAccount() {
            $scope.account = {
                HouseHold: $scope.houseHold,
                Name: $scope.Name,
                Balance: $scope.Balance,
                ReconciledBalance: $scope.ReconciledBalance
            };
            accountsService.createAccount($scope.account).then(function (res) {
                $scope.account = res.data;
                $state.go('Accounts');
            });
        }
 
        $scope.getAccounts();

    }]);

