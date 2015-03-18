angular.module('app')
.controller('AccountCreateController', ['$scope', '$state', '$stateParams', 'accountsService', 'authService',
    function ($scope, $state, $stateParams, accountsService, authService) {
        function createAccount() {
            //NEW ACCOUNT SETUP HERE
            accountsService.createAccount($scope.account).then(function (res) {
                $scope.Account = res.data;
            });
        }

        createAccount();

    }]);

