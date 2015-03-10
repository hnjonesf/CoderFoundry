(function () {
    'use strict';

    angular.module('app')
        .controller('CreateTransactionModalCtrl', CreateTransactionModalCtrl);

    CreateTransactionModalCtrl.$inject = ['$scope', '$modalInstance', 'transactionServices', 'AccountId', 'Categories'];

    function CreateTransactionModalCtrl($scope, $modalInstance, transactionServices, AccountId, Categories) {

        $scope.createTransaction = createTransaction;
        $scope.categories = Categories;
        $scope.newTransaction = {
            AccountId: AccountId,
            Amount: 0,
            Reconciled: false,
            Date: "",
            Description: "",
            Category: ""
        };

        $scope.createTransaction = createTransaction;

        /////////////////////

        function createTransaction() {
            transactionServices.createTransaction($scope.newTransaction).then(function (res) {
                //you need to add the recently added transaction into $scope.Transactions
                $modalInstance.close($scope.newTransaction);
            }, function (res) {
                $modalInstance.dismiss();
            });
        }

    }
}());
