(function () {
    'use strict';

    angular.module('app')
        .controller('CreateAccountModalController', CreateAccountModalController);

    CreateAccountModalController.$inject = ['$scope', '$modalInstance', 'accountServices'];

    function CreateAccountModalController($scope, $modalInstance, accountServices) {

        $scope.createAccount = createAccount;
        $scope.newAccount = {
            Name: '',
            Household: '',
            Balance: 0,
            ReconciledBalance: 0
        };

        function createAccount() {
            accountServices.createAccount($scope.newAccount).then(function (res) {
                $modalInstance.close($scope.newAccount);
            }, function (res) {
                $modalInstance.dismiss();
            });
        }

    }
}());