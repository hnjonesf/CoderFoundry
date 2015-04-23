angular.module('app')
.controller('TransactionsController', ['$scope', '$state', '$stateParams', 'transactions', 'categories',
    function ($scope, $state, $stateParams, transactions, categories) {

        $scope.categories = categories;
        $scope.accountId = $stateParams.accountId;
        $scope.transactions = transactions;

        $scope.filterOptions = {
        filterText: ''
        };

        //$scope.categoryName = function (CategoryId) { return categories[transaction.CategoryId].Name; };
        //$scope.categoryName = function () {
        //    categories[transaction.CategoryId].Name;
        //};

        //Hugh Enable SELECT and edit of a transaction.
        $scope.selectedRows = [];

        $scope.gridOptions = {
            data: 'transactions',
            showSelectionCheckbox: true,
            selectedItems: $scope.selectedRows,
            enableCellSelection: true,
            enableCellEdit: true,
            showFooter: true,
            showGroupPanel: true,
            filterOptions: $scope.filterOptions,
            jqueryUIDraggable: true,
            columnDefs: [{ field: 'Date', displayName: 'Date', width: "*", cellFilter: "date:'MM-dd-yyyy'" },
                        { field: 'Description', displayName: 'Description', width: "*" },
                        { field: 'CategoryId', cellClass: 'Category', width: "*" },
                        { field: 'Amount', displayName: 'Amount', width: "*", cellFilter: 'currency' },
                        { field: 'Reconcilled', cellClass: 'Reconcilled', width: "*" },
                        { field: 'UpdatedByUserId', cellClass: 'Updated By', width: "*" }
                        ]
        }

    }]);