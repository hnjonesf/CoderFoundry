angular.module('app')
.controller('TransactionsController', ['$scope', '$state', '$stateParams', 'transactionsService', 'authService',
    function ($scope, $state, $stateParams, transactionsService, authService) {

        //SETUP ACCOUNT TIES TO HOUSEHOLD
        $scope.houseHold = authService.authentication.houseHold;
        $scope.Name = "";


        //get accounts
        $scope.getTransactions = function () {
            transactionsService.getTransactions($scope.houseHold).then(function (data) {
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
            });
        }

        $scope.getTransaction();

    }]);

