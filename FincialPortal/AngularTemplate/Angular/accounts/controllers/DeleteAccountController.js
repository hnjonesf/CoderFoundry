angular.module('app')
.controller('DeleteAccountController', ['$scope', '$state', '$stateParams', 'accountsService', 'authService', 'account',
    function ($scope, $state, $stateParams, accountsService, authService, account) {

        $scope.account = account;
        //delete account
        $scope.deleteAccount = function deleteAccount() {
            accountsService.deleteAccount($scope.account).then(function (res) {
                $state.go('Accounts');
            });
        }

    }]);