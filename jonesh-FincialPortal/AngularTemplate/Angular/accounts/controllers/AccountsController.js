angular.module('app')
.controller('AccountsController', ['$scope', '$state', '$stateParams', '$filter', 'accountsService', 'authService', 'ngTableParams','categoriesService', 'transactions',
    function ($scope, $state, $stateParams, $filter, accountsService, authService, ngTableParams, categoriesService) {
        $scope.transactions = transactions;

        //SETUP ACCOUNT TIES TO HOUSEHOLD
        $scope.houseHold = authService.authentication.houseHold;
        $scope.Name = "";
        $scope.Balance = "";
        $scope.ReconciledBalance = "";


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
                $state.go('Accounts');
            });
        }



        //GET TRANSACTIONS
        $scope.getTransactions = function () {
            accountsService.getTransactions($scope.AccountId).then(function (data) {
                $scope.transactions = data;
            });
        }

        //CREATE TRANSACTION
        $scope.createTransaction = function createTransaction() {
            $scope.transaction = {
                AccountId: $scope.AccountId,
                Amount: $scope.Amount,
                AbsAmount: $scope.AbsAmount,
                ReconciledAmount: $scope.ReconciledAmount,
                AbsReconciledAmount: $scope.AbsReconciledAmount,
                Date: $scope.Date,
                Description: $scope.Description,
                Updated: $scope.Date,
                UpdatedByUserId: $scope.UpdatedByUserId,
                CategoryId: $scope.CategoryId
            };
            accountsService.createTransaction($scope.transaction).then(function (res) {
                $scope.transaction = res.data;
                $state.go('Transactions');
            });
        }


        $scope.getAccounts();

    }]);

