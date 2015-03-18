angular.module('app')
.controller('AccountDeleteController', ['$scope', '$state', '$stateParams', 'accountsService', 'authService',
    function ($scope, $state, $stateParams, accountsService, authService) {
        function deleteAccount() {
            accountsService.deleteAccount($scope.account).then(function (res) {
                $scope.Account = res.data;
            });
        }

        deleteAccount();

    }]);

