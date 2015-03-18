angular.module('app')
.controller('AccountEditController', ['$scope', '$state', '$stateParams', 'accountsService', 'authService',
    function ($scope, $state, $stateParams, accountsService, authService) {
        function editAccount() {
            accountsService.editAccount($scope.account).then(function (res) {
                $scope.Account = res.data;
            });
        }

        editAccount();

    }]);

