  'use strict';
angular.module( 'app' )
    .factory('accountsService', ['$http', function ($http) {

        var factory = {};
        factory.getAccounts = function (houseHold) {
            var options = { params: { houseHold: houseHold } };
            return $http.get('/api/accounts/GetAccounts', options).then(function (response) {
                return response.data;
            });
        };


        factory.getTransactions = function (accountId) {
            var options = { params: { accountId: accountId } };
            return $http.get('/api/transactions/GetTransactions', options).then(function (response) {
                return response.data;
            });
        };

        factory.getAccount = function (id) {
            var options = { params: { id: id } };
            return $http.get('/api/accounts/GetAccount', options)

                .then(function (response) {
                return response.data;
            });
        };

        factory.createAccount = function (account) {
            return $http.post('/api/accounts/CreateAccount', account).then(function (response) {
                return response.data;
            });
        };

        factory.deleteAccount = function (id) {
            var options = { params: { id: id } };
            return $http.delete('/api/accounts/DeleteAccount', options).then(function (response) {
                return response.data;
            });
        };

        factory.editAccount = function (account) {
            return $http.put('/api/accounts/EditAccount', account).then(function (response) {
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