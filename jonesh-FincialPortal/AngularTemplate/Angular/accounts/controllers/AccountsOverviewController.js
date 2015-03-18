angular.module('app')
.controller('AccountsOverviewController', ['$scope', '$state', '$stateParams', 'accountsService', 'authService',
    function ($scope, $state, $stateParams, accountsService, authService) {
        $scope.houseHold = authService.authentication.houseHold;
        function getAccounts() {
            accountsService.getAccounts($scope.houseHold).then(function (res) {
                $scope.Accounts = res.data;
                console.info('GetAccount succeeded');
            }, function (res) {
                console.info('GetAccount failed');
            });
        }

        getAccounts();

    }]);

