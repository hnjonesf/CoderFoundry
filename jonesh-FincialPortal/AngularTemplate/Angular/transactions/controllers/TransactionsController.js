angular.module('app')
.controller('TransactionsController', ['$scope', '$state', '$stateParams', 'transactions', 'categories',
    function ($scope, $state, $stateParams, transactions, categories) {

        $scope.categories = categories;
        $scope.accountId = $stateParams.accountId;
        $scope.transactions = transactions;

        //$scope.gridOptions = {
        //    data: 'transactions'
        //};
        ////
        //$scope.gridOptionsTwo = {
        //    data: 'transactions',
        //    showGroupPanel: true,
        //    jqueryUIDraggable: true
        //}

    }]);

