'use strict';
angular.module('app')
    .factory('transactionsService', ['$http', function ($http) {

        var factory = {};

        factory.getTransactions = function (accountId) {
            var options = { params: { accountId: accountId } };
            return $http.get('/api/transactions/GetTransactions', options).then(function (response) {
                return response.data;
            });
        };

        factory.getTransaction = function (id) {
            var options = { params: { id: id } };
            return $http.get('/api/transactions/GetTransaction', options).then(function (response) {
                return response.data;
            });
        };

        factory.createTransaction = function (account) {
            return $http.post('/api/transactions/CreateTransaction', account).then(function (response) {
                return response.data;
            });
        };

        factory.deleteTransaction = function (id) {
            var options = { params: { id: id } };
            return $http.delete('/api/transactions/DeleteTransaction', options).then(function (response) {
                return response.data;
            });
        };

        factory.editTransaction = function (account) {
            return $http.put('/api/transactions/EditTransaction', account).then(function (response) {
                return response.data;
            });
        };

        return factory;

    }]);