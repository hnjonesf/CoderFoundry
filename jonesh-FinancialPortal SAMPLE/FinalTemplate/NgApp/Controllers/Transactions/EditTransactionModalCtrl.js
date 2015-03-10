(function () {

    'use strict';

    angular.module('app')
        .controller('EditTransactionModalCtrl', EditTransactionModalCtrl);

    EditTransactionModalCtrl.$inject = ['$scope', 'Transaction', 'transactionServices', '$modalInstance', 'Categories'];

    function EditTransactionModalCtrl($scope, Transaction, transactionServices, $modalInstance, Categories, stateParams) {
        $scope.editTransaction = {};
        angular.extend($scope.editTransaction, Transaction);
        $scope.reconciledOptions = ['true', 'false'];
        $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
        $scope.format = $scope.formats[0];
        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };
        $scope.categories = Categories;
        $scope.updateTransaction = updateTransaction;
        $scope.editTransaction.reconciled = eval($scope.editTransaction.reconciled);

        /////////////////////////////

        function updateTransaction(transaction) {
            transactionServices.editTransaction(transaction).then(function (res) {
                $modalInstance.close(transaction);
            }, function (res) {
                $modalInstance.dismiss();
            });
        }
    }
}());
