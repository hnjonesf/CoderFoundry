'use strict';

(function () {
    angular.module('app')
        .factory('accountServices', ['$scope', '$http', 'accountServices',
            function ($scope, $http, accountServices) {

                return {
                    getAccounts: getAccounts,
                    createAccount: createAccount,
                    editAccount: editAccount,
                    deleteAccount: deleteAccount
                }

                function getAccounts() {
                    return $http.get('api/accounts/GetAccounts');
                }

                function createAccount(account) {
                    return $http.post('api/accounts/CreateAccount', account);
                }

                function editAccount(account) {
                    return $http.put('api/accounts/EditAccount', account);
                }

                function deleteAccount(id) {
                    return $http.delete('api/accounts/DeleteAccount', { params: { "Id": id } });
                }


            }])
});