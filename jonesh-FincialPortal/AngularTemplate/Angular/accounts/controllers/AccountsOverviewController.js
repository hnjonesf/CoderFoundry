﻿angular.module('app')
.controller('AccountsOverviewController', ['$scope', '$state', '$stateParams', 'accountsService', 'authService',
    function ($scope, $state, $stateParams, accountsService, authService) {

        //SETUP ACCOUNT TIES TO HOUSEHOLD
        $scope.houseHold = authService.authentication.houseHold;
        $scope.Name = "";
        $scope.Balance = "";
        $scope.ReconciledBalance = "";


        //get accounts
        $scope.getAccounts = function () {            
            accountsService.getAccounts($scope.houseHold).then(function (data) {
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
                $scope.Account = res.data;
            });
        }


        //delete account
        $scope.deleteAccount = function deleteAccount() {
            accountsService.deleteAccount($scope.account).then(function (res) {
                $scope.Account = res.data;
            });
        }


        //edit account
        $scope.editAccount = function editAccount() {
            accountsService.editAccount($scope.account).then(function (res) {
                $scope.Account = res.data;
            });
        }
 
        $scope.getAccounts();

    }]);

