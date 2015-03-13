(function () {

    'use strict';

    angular.module('app').controller('TransactionsCtrl', TransactionsCtrl);

    TransactionsCtrl.$inject = ['$scope', 'transactionServices', '$modal', '$templateCache', '$stateParams'];

    function TransactionsCtrl($scope, transactionServices, $modal, $templateCache, $stateParams) {

        $scope.createTransaction = createTransaction;
        $scope.editTransaction = editTransaction;
        $scope.deleteTransaction = deleteTransaction;
        $scope.currentTransaction = {};
        $scope.sortDir = false;
        $scope.categories = transactionServices.getCategories();
        $scope.paginationSettings = {
            totalItems: 6,
            currentPage: 1,
            maxPages: 10,
            itemsPerPage: 5
        }


        getTransactions($stateParams.accountId);
        ///////////

        function getTransactions(accountId) {
            transactionServices.getTransactions(parseInt(accountId)).then(function (res) {
                $scope.Transactions = res.data;
                $scope.paginationSettings.totalItems = $scope.Transactions.length;
                console.info('GetTransaction succeeded');
            }, function (res) {
                console.info('GetTransaction failed');
            });
        }

        function createTransaction() {

            var modalInstance = $modal.open({
                templateUrl: 'NgApp/Views/Transactions/CreateTransactionModal.html',
                controller: 'CreateTransactionModalCtrl',
                resolve: {
                    AccountId: function () {
                        return $stateParams.accountId;
                    },
                    Categories: function () {
                        return $scope.categories;
                    }
                }
            });

            modalInstance.result.then(function (createdTransaction) {
                getTransactions($stateParams.accountId);
            }, function () {
                //
            });
        }

        function editTransaction(transaction) {
            var modalInstance = $modal.open({
                templateUrl: 'NgApp/Views/Transactions/EditTransactionModal.html',
                controller: 'EditTransactionModalCtrl',
                resolve: {
                    Transaction: function () {
                        return transaction;
                    },
                    Categories: function () {
                        return $scope.categories;
                    },
                }
            });

            modalInstance.result.then(function (selectedItem) {
                getTransactions($stateParams.accountId);
                }, function () {

                });
        }

        function deleteTransaction(transaction) {
            var modalInstance = $modal.open({
                templateUrl: 'NgApp/Views/Transactions/DeleteTransactionModal.html'
            });

            modalInstance.result.then(function () {
                transactionServices.deleteTransaction(transaction.id, $stateParams.accountId).then(function (res) {
                    getTransactions($stateParams.accountId);
                    console.info('transaction deleted');
                });
            }, function () {
                //
            });
        }

        $scope.loadTransaction = function (transaction) {
            console.log(transaction);
            $scope.currentTransaction = transaction;
        }

    }

}());

