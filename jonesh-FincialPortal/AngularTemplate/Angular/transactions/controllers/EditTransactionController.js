angular.module('app')
.controller('EditTransactionController', ['$scope', '$state', '$stateParams', 'accountsService', 'authService', 'transaction',
    function ($scope, $state, $stateParams, accountsService, authService, transaction) {

        $scope.transaction = transaction;


    }]);

