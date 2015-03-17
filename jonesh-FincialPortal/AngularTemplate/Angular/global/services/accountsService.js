  'use strict';
angular.module('app')
    .factory('accountsService', ['$http', function ($http) {

        var factory = {}; 
        factory.getAccounts = function () {
            return $http.get('/api/accounts').then(function (response) {
                return response.data;
            });
        };

}]);


//factory.getAccounts = function () {
//    return $http.get('api/accounts/GetAccount')
//    .then(function (response) {
//        return response.data;
//    });
//};


//function getAccounts() {
//    return $http.get('api/accounts/GetAccounts');
//}

//function createAccount(account) {
//    return $http.post('api/accounts/CreateAccount', account);
//}

//function editAccount(account) {
//    return $http.put('api/accounts/EditAccount', account);
//}

//function deleteAccount(id) {
//    return $http.delete('api/accounts/DeleteAccount', { params: { "Id": id } });
//}

