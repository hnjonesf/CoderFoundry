angular.module('app')
.controller('TransactionsController', ['$scope', '$state', '$stateParams', 'transactions',
    function ($scope, $state, $stateParams, transactions) {

        $scope.accountId = $stateParams.accountId;
        $scope.transactions = transactions;

    }]);

