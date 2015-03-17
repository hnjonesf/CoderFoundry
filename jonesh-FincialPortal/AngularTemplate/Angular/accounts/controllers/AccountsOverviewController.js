(function () {
    angular.module('app')
        .controller('AccountsOverviewController', ['$scope', '$state', '$stateParams', 'accountServices', function ($scope, $state, $stateParams, accountServices) {
            function getAccounts() {
                console.log("HELP!!! AccountsOverviewController");
                accountServices.getAccounts().then(function (res) {
                    $scope.Accounts = res.data;
                    console.info('GetAccount succeeded');
                }, function (res) {
                    console.info('GetAccount failed');
                });
            }
        }])
})();