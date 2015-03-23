angular.module('app')
.controller('TransactionsController', ['$scope', '$state', '$stateParams', 'accountsService', 'authService',
    function ($scope, $state, $stateParams, accountsService, authService) {

        //SETUP TRANSACTION TIES TO ACCOUNT
 //       $scope.account.Name = $state.params.id;
        $scope.AccountId = $state.params.id;



    }]);

