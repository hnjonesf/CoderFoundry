(function () {
    'use strict';

    angular.module('app')
        .controller('CreateAccountModalCtrl', CreateAccountModalCtrl);

    CreateAccountModalCtrl.$inject = ['$scope','$modalInstance', 'accountServices'];

    function CreateAccountModalCtrl($scope, $modalInstance, accountServices) {

        $scope.createAccount = createAccount;
        $scope.newAccount = {
            Name: '',
            Balance: 0,
            ReconciledBalance: 0
        };

        /////////////////////

        function createAccount() {
            accountServices.createAccount($scope.newAccount).then(function (res) {
                //you need to add the recently added account into $scope.Accounts
                $modalInstance.close($scope.newAccount);
            }, function (res) {
                $modalInstance.dismiss();
            });
        }

    }
}());