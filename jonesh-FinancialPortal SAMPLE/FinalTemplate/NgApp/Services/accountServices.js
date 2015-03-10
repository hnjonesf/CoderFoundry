(function () {

    'use strict';

    angular.module('app')
        .factory('accountServices', accountServices);

    accountServices.$inject = ['$http'];

    function accountServices($http){
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
    }
}());

