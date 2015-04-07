angular.module('app')
.controller('CreateTransactionController', ['$scope', '$state', '$stateParams', 'accountsService', 'categories',
    function ($scope, $state, $stateParams, accountsService,  categories) {

        $scope.categories = categories;
        $scope.accountId = $stateParams.accountId;

        $scope.transaction = {
            AccountId: $scope.accountId,
            Amount: 0.00,
            AbsAmount: 0.00,
            ReconciledAmount: 0.00,
            AbsReconciledAmount: 0.00,
            Date: null,
            Description: "",
            Updated: null,
            UpdatedByUserId: null,
            CategoryId: null
        };

        //CREATE TRANSACTION
        $scope.createTransaction = function createTransaction() {

            accountsService.createTransaction($scope.transaction).then(function () {
                $state.go('Transactions', {accountId: $scope.accountId});
            });
        }

    }]);

