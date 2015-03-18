  'use strict';
angular.module( 'app' )
    .factory('accountsService', ['$http', function ($http) {

        var factory = {};
        factory.getAccounts = function (houseHold) {
            var options = { params: { houseHold: houseHold } };
            return $http.get('/api/accounts/GetAccounts',options).then(function (response) {
                return response.data;
            });
        };

        return factory;

}]);

//from cars...
//factory.getMakes = function (year) {
//    var options = { params: { year: year } };
//    return $http.get('/api/makes', options)
//        .then(function (response) {
//            return response.data;
//        });
//};
//from cars...
//scope.getMakes = function () {
//carSvc.getMakes(scope.selectedYear)
//.then(function (data) {
//    scope.makes = data;
//});
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

