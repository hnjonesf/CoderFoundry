angular.module('app')
.controller('AccountsOverviewController', ['$scope', '$state', '$stateParams', 'accountsService', 'authService',
    function ($scope, $state, $stateParams, accountsService, authService) {
        $scope.houseHold = authService.authentication.houseHold;
        $scope.accounts = [];
        $scope.getAccounts = function () {            
            accountsService.getAccounts($scope.houseHold).then(function (data) {
                $scope.accounts = data;
            });
        }
        $scope.getAccounts();



    }]);

