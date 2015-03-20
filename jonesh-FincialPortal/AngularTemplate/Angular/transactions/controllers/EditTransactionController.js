angular.module('app')
.controller('EditTransactionController', ['$scope', '$state', '$stateParams', 'transactionsService', 'authService', 'transaction',
    function ($scope, $state, $stateParams, transactionsService, authService, transaction) {

        $scope.transaction = transaction;

        //edit or delete account
        $scope.editTransaction = function editTransaction() {
            transactionsService.editTransaction($scope.transaction).then(function (res) {
                $state.go('Transactions');
            });
        }

        //delete account
        $scope.deleteTransaction = function deleteTransaction() {
            transactionsService.deleteTransaction($scope.transaction.Id).then(function (res) {
                $state.go('Transactions');
            });
        }


    }]);

