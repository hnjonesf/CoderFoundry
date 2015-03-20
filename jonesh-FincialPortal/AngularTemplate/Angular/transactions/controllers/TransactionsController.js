angular.module('app')
.controller('TransactionsController', ['$scope', '$state', '$stateParams', 'transactionsService', 'authService',
    function ($scope, $state, $stateParams, transactionsService, authService) {

        //SETUP TRANSACTION TIES TO ACCOUNT
        $scope.AccountId = $scope.accountId;


        //get accounts
        $scope.getTransactions = function () {
            transactionsService.getTransactions($scope.AccountId).then(function (data) {
                $scope.Transactions = data;
            });
        }


        //create account
        $scope.createTransaction = function createTransaction() {
            $scope.transaction = {
                AccountId: $scope.AccountId,
                Amount: $scope.Amount,
                AbsAmount: $scope.AbsAmount,
                ReconciledAmount: $scope.ReconciledAmount,
                AbsReconciledAmount: $scope.AbsReconciledAmount,
                Date: $scope.Date,
                Description: $scope.Description,
                Updated: $scope.Updated,
                UpdatedByUserId: $scope.UpdatedByUserId,
                CategoryId: $scope.CategoryId,
            };
            transactionsService.createTransaction($scope.transaction).then(function (res) {
                $scope.transaction = res.data;
                $state.go('Transactions');
            });
        }

        $scope.getTransaction();

    }]);

