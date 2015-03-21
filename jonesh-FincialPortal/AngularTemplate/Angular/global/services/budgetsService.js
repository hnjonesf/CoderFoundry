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

        factory.createBudget = function (budget) {
            return $http.post('/api/budgets/CreateBudget', budget).then(function (response) {
                return response.data;
            });
        };

        factory.deleteBudget = function (id) {
            var options = { params: { id: id } };
            return $http.delete('/api/budgets/DeleteBudget', options).then(function (response) {
                return response.data;
            });
        };

        factory.editBudget = function (budget) {
            return $http.put('/api/budgets/EditBudget', budget).then(function (response) {
                return response.data;
            });
        };

        return factory;

    }]);