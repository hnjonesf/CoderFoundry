﻿angular.module('app')
.controller('EditAccountController', ['$scope', '$state', '$stateParams', 'accountsService', 'authService', 'account',
    function ($scope, $state, $stateParams, accountsService, authService, account) {

        $scope.account = account;

        //edit account
        $scope.editAccount = function editAccount() {
            accountsService.editAccount($scope.account).then(function (res) {
                $state.go('Accounts.List');
            });
        }

        //delete account
        $scope.deleteAccount = function deleteAccount() {
            accountsService.deleteAccount($scope.account.Id).then(function (res) {
                $state.go('Accounts.List');
            });
        }


    }]);

