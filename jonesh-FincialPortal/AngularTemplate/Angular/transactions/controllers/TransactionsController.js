angular.module('app')
.controller('TransactionsController', ['$scope', '$state', '$stateParams', 'accountsService', 'authService',
    function ($scope, $state, $stateParams, accountsService, authService) {

        //SETUP TRANSACTION TIES TO ACCOUNT
        $scope.AccountId = $state.params.id;

        //GET TRANSACTIONS
        $scope.getTransactions = function () {
            accountsService.getTransactions($scope.accountId).then(function (data) {
                $scope.transactions = data;
            });
        }

        //CREATE TRANSACTION
        $scope.createTransaction = function createTransaction() {
            $scope.transaction = {
                AccountId: $scope.account.Id,
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

        $scope.getTransactions();

    }]);

