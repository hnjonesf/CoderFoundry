angular.module('app')
.controller('AccountsController', ['$scope', '$state', '$stateParams', '$filter', 'accountsService', 'authService','categoriesService',
    function ($scope, $state, $stateParams, $filter, accountsService, authService, categoriesService) {

        //GRID Options


        //ACCOUNT TO HOUSEHOLD
        $scope.houseHold = authService.authentication.houseHold;
        $scope.Name = "";
        $scope.Balance = "";
        $scope.ReconciledBalance = "";
       
        //UI Grid Setup
        $scope.gridOptions = {
            data: 'accounts',
            columnDefs: [{ field: "Name" },
            { field: "Balance" },
            { field: "ReconciledBalance" }]
        };

        //$scope.filterOptions = {
        //    filterText: ""
        //};

        //$scope.pagingOptions = {
        //    pageSizes: [25, 50, 100],
        //    pageSize: 25,
        //    totalServerItems: 0,
        //    currentPage: 1
        //};

        //$scope.setPagingData = function (data, page, pageSize) {
        //    var pagedData = data.slice((page - 1) * pageSize, page * pageSize);
        //    $scope.myData = pagedData;
        //    $scope.pagingOptions.totalServerItems = data.length;
        //    if (!$scope.$$phase) {
        //        $scope.$apply();
        //    }
        //};

        //$scope.getPagedDataAsync = function (pageSize, page) {
        //    setTimeout(function () {
        //        $http.get('json').success(function (largeLoad) {
        //            $scope.setPagingData(largeLoad, page, pageSize);
        //        });
        //    }, 100);
        //};

        //$scope.$watch('pagingOptions', function () {
        //    $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage, $scope.filterOptions.filterText);
        //}, true);

        //$scope.gridOptions = {
        //    data: 'accounts',
        //    showFooter: true
        //};

        //$scope.gridOptions.columnDefs = 'gridColumnDefs';







        //CATEGORIES FOR A HOUSEHOLD TO BE USED IN A SELECT LIST

        //get accounts
        $scope.getAccounts = function () {            
            accountsService.getAccounts($scope.houseHold)
                .then(function (data) {
                $scope.accounts = data;
            });
        }

        //create account
        $scope.createAccount = function createAccount() {
            $scope.account = {
                HouseHold: $scope.houseHold,
                Name: $scope.Name,
                Balance: $scope.Balance,
                ReconciledBalance: $scope.ReconciledBalance
            };
            accountsService.createAccount($scope.account).then(function (res) {
                $scope.account = res.data;
                $state.go('Accounts.List');
            });
        }

        $scope.getAccounts();

    }]);

