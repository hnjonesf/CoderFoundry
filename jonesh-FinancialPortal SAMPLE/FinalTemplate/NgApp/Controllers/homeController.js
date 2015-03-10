(function () {

    'use strict';

    angular.module('app').controller('HomeCtrl', HomeCtrl);

    HomeCtrl.$inject = ['$scope', 'homeServices'];

    function HomeCtrl($scope, homeServices) {

        getAccounts();
        getTransactions();
        ///////////

        function getAccounts() {
            homeServices.getAccounts().then(function (res) {
                $scope.Accounts = res.data;
                console.info('GetAccount succeeded');
            }, function (res) {
                console.info('GetAccount failed');
            });
        }

        function getTransactions() {
            homeServices.getTransactions().then(function (res) {
                $scope.Transactions = res.data;
                console.info('GetTransactions succeeded');
            }, function (res) {
                console.info('GetTransactions failed');
            });
        }
    }

}());

