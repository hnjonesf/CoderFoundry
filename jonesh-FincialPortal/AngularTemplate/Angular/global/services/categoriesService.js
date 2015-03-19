  'use strict';
angular.module( 'app' )
    .factory('categoriesService', ['$http', function ($http) {

        var factory = {};

        factory.getCategories = function (houseHold) {
            var options = { params: { houseHold: houseHold } };
            return $http.get('/api/accounts/GetCategories', options).then(function (response) {
                return response.data;
            });
        };

        factory.createCategory = function (account) {
            var options = { params: { account: account } };
            return $http.post('/api/accounts/CreateCategory', options).then(function (response) {
                console.log(response);
                return response.data;
            });
        };

        factory.deleteCategory = function (account) {
            var options = { params: { account: account } };
            return $http.delete('/api/accounts/DeleteCategory', options).then(function (response) {
                return response.data;
            });
        };

        factory.editCategory = function (account) {
            var options = { params: { account: account } };
            return $http.put('/api/accounts/editCategory', options).then(function (response) {
                return response.data;
            });
        };

        return factory;

}]);