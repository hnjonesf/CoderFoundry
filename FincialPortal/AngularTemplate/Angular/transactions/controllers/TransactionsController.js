angular.module('app')
.controller('TransactionsController', ['$scope', '$state', '$stateParams', 'transactions', 'categories',
    function ($scope, $state, $stateParams, transactions, categories) {

        $scope.categories = categories;
        $scope.accountId = $stateParams.accountId;
        $scope.transactions = transactions;

        //
        $scope.gridOptions = {
            data: 'transactions',
            showGroupPanel: true,
            jqueryUIDraggable: true,
            columnDefs: [{ field: 'Description', displayName: 'Description', width: "*" },
                                    { field: 'Amount', displayName: 'Amount', width: "*" },
                                    { field: 'Date', displayName: 'Date', width: "*" },
                                    { field: 'CategoryId', cellClass: 'Category', width: "*" }]
        }

        console.log(transactions);

    }]);

