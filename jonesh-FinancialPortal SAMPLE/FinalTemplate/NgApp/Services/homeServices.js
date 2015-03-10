(function () {

    'use strict';

    angular.module('app')
        .factory('homeServices', homeServices);

    homeServices.$inject = ['$http'];

    function homeServices($http) {
        return {
            getAccounts: getAccounts,
            getTransactions: getTransactions,
        }

        function getAccounts() {
            return $http.get('api/home/GetAccounts');
        }

        function getTransactions() {
            return $http.get('api/home/GetTransactions');
        }

    }
}());


