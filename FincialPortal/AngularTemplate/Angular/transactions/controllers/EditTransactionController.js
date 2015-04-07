angular.module('app')
.controller('EditTransactionController', ['$scope', '$state', '$stateParams', 'accountsService', 'authService', 'transaction','categories',
    function ($scope, $state, $stateParams, accountsService, authService, transaction, categories) {

        $scope.transaction = transaction;
        $scope.categories = categories;
        $scope.accountId = $stateParams.accountId;

        //edit transaction
        $scope.editTransaction = function editTransaction() {
            accountsService.editTransaction($scope.transaction).then(function (res) {
                $state.go('Transactions', { accountId: $scope.transaction.AccountId });
            });
        }

        //delete account
        $scope.deleteTransaction = function deleteTransaction() {
            accountsService.deleteTransaction($scope.transaction.Id).then(function (res) {
                $state.go('Transactions', { accountId: $scope.transaction.AccountId });
            });
        }


    }]);

