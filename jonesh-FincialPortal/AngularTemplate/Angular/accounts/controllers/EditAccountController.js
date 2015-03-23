angular.module('app')
.controller('EditAccountController', ['$scope', '$state', '$stateParams', 'accountsService', 'authService', 'account',
    function ($scope, $state, $stateParams, accountsService, authService, account) {

        $scope.account = account;

        //edit or delete account
        $scope.editAccount = function editAccount() {
            accountsService.editAccount($scope.account).then(function (res) {
                $state.go('Accounts');
            });
        }

        //delete account
        $scope.deleteAccount = function deleteAccount() {
            accountsService.deleteAccount($scope.account.Id).then(function (res) {
                $state.go('Accounts');
            });
        }


        //edit or delete account
        $scope.editTransaction = function editTransaction() {
            accountsService.editTransaction($scope.transaction).then(function (res) {
                $state.go('Transactions');
            });
        }

        //delete account
        $scope.deleteTransaction = function deleteTransaction() {
            accountsService.deleteTransaction($scope.transaction.Id).then(function (res) {
                $state.go('Transactions');
            });
        }


    }]);

