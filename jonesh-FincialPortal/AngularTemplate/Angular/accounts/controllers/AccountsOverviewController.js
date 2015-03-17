angular.module('app')
.controller('AccountsOverviewController', ['$scope', '$state', '$stateParams',
    function ($scope, $state, $stateParams) {
        $scope.Account = {
            name: "Checking",
            balance: 333.32,
            reconciledBalance: 333.31
        };

        return ($scope.Account);


}]);     