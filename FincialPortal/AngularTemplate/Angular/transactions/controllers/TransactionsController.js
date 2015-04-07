angular.module('app')
.controller('TransactionsController', ['$scope', '$state', '$stateParams', 'transactions', 'categories',
    function ($scope, $state, $stateParams, transactions, categories) {

        $scope.categories = categories;
        $scope.accountId = $stateParams.accountId;
        $scope.transactions = transactions;

        $scope.filterOptions = {
    filterText: ''
  };

        //
        $scope.gridOptions = {
            data: 'transactions',
            showGroupPanel: true,
            filterOptions: $scope.filterOptions,
            jqueryUIDraggable: true,
            columnDefs: [{ field: 'Description', displayName: 'Description', width: "*" },
                                    { field: 'Amount', displayName: 'Amount', width: "*" },
                                    { field: 'Date', displayName: 'Date', width: "*" },
                                    { field: 'CategoryId', cellClass: 'Category', width: "*" }]
        }

        console.log(transactions);

    }]);

