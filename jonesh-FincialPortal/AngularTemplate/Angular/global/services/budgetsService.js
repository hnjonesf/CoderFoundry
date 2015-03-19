'use strict';
angular.module('app')
    .factory('budgetsService', ['$http', function ($http) {

        var factory = {};
        factory.getBudgets = function (houseHold) {
            var options = { params: { houseHold: houseHold } };
            return $http.get('/api/budgets/GetBudgets', options).then(function (response) {
                return response.data;
            });
        };

        factory.getBudget = function (id) {
            var options = { params: { id: id } };
            return $http.get('/api/budgets/GetBudget', options).then(function (response) {
                return response.data;
            });
        };

        factory.createBudget = function (account) {
            return $http.post('/api/budgets/CreateBudget', account).then(function (response) {
                return response.data;
            });
        };

        factory.deleteBudget = function (id) {
            var options = { params: { id: id } };
            return $http.delete('/api/budgets/DeleteBudget', options).then(function (response) {
                return response.data;
            });
        };

        factory.editBudget = function (account) {
            return $http.put('/api/budgets/EditBudget', account).then(function (response) {
                return response.data;
            });
        };

        return factory;

    }]);