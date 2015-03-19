'use strict';
angular.module('app')
    .factory('categoriesService', ['$http', function ($http) {

        var factory = {};
        factory.getCategories = function (houseHold) {
            var options = { params: { houseHold: houseHold } };
            return $http.get('/api/categories/GetCategories', options).then(function (response) {
                return response.data;
            });
        };

        factory.getCategory = function (id) {
            var options = { params: { id: id } };
            return $http.get('/api/categories/GetCategory', options).then(function (response) {
                return response.data;
            });
        };

        factory.createCategory = function (account) {
            return $http.post('/api/categories/CreateCategory', account).then(function (response) {
                return response.data;
            });
        };

        factory.deleteCategory = function (id) {
            var options = { params: { id: id } };
            return $http.delete('/api/categories/DeleteCategory', options).then(function (response) {
                return response.data;
            });
        };

        factory.editCategory = function (account) {
            return $http.put('/api/categories/EditCategory', account).then(function (response) {
                return response.data;
            });
        };

        return factory;

    }]);