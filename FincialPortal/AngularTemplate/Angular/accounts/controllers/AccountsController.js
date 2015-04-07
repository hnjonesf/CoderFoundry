angular.module('app')
.controller('AccountsController', ['$scope', '$state', '$stateParams', '$filter', 'accountsService', 'authService','categoriesService',
    function ($scope, $state, $stateParams, $filter, accountsService, authService, categoriesService) {

        //ACCOUNT TO HOUSEHOLD
        $scope.houseHold = authService.authentication.houseHold;
        $scope.Name = "";
        $scope.Balance = "";
        $scope.ReconciledBalance = "";


        //CATEGORIES FOR A HOUSEHOLD TO BE USED IN A SELECT LIST

        //get accounts
        $scope.getAccounts = function () {            
            accountsService.getAccounts($scope.houseHold)
                .then(function (data) {
                $scope.accounts = data;
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
                $state.go('Accounts.List');
            });
        }

        $scope.getAccounts();

    }]);

