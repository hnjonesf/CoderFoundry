angular.module('app')
.controller('EditTransactionController', ['$scope', '$state', '$stateParams', 'accountsService', 'authService', 'transaction',
    function ($scope, $state, $stateParams, accountsService, authService, transaction) {

        $scope.transaction = transaction;


        //edit transaction
        $scope.editTransaction = function editTransaction() {
            accountsService.editTransaction($scope.transaction).then(function (res) {
                $state.go('Transactions', { accountId: $scope.accountId });
            });
        }


    }]);

