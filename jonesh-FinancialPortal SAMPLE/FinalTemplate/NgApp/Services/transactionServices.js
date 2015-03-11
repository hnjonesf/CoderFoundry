(function () {

    'use strict';

    angular.module('app')
        .factory('transactionServices', transactionServices);

    transactionServices.$inject = ['$http'];

    function transactionServices($http) {
        return {
            getTransactions: getTransactions,
            createTransaction: createTransaction,
            editTransaction: editTransaction,
            deleteTransaction: deleteTransaction,
            getCategories: getCategories
        }

        function getTransactions(accountId) {
            return $http.get('api/transactions/GetTransactions', { params: { 'accountId': accountId } });
        }

        function createTransaction(transaction) {
            return $http.post('api/transactions/CreateTransaction', transaction);
        }

        function editTransaction(transaction) {
            return $http.put('api/transactions/EditTransaction', transaction);
        }

        function deleteTransaction(id, accountId) {
            return $http.delete('api/transactions/DeleteTransaction', { params: { "Id": id , "accountId" : accountId} });
        }

        function getCategories() {
            return [
                    
                    'Apparel' ,
                    'Food' ,
                    'HealthCare' ,
                    'Housing' ,
                    'Income' ,
                    'Investments' ,
                    'Other' ,
                    'Transportation' ,
                    'Utilities'
            ]
        }
    }
}());


