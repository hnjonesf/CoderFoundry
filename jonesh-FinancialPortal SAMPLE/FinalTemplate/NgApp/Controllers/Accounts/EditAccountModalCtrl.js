(function () {

    'use strict';

    angular.module('app')
        .controller('EditAccountModalCtrl', EditAccountModalCtrl);

    EditAccountModalCtrl.$inject = ['$scope', 'account', 'accountServices', '$modalInstance'];

    function EditAccountModalCtrl($scope, account, accountServices, $modalInstance) {
        $scope.editAccount = angular.copy(account);
        $scope.updateAccount = updateAccount;

        /////////////////////////////


        function updateAccount(account) {
            accountServices.editAccount(account).then(function (res) {
                $modalInstance.close(account);
            }, function (res) {
                $modalInstance.dismiss();
            });
        }
    }
}());