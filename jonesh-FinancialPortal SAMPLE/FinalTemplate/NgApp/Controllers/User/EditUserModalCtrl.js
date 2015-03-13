(function () {

    'use strict';

    angular.module('app')
        .controller('EditUserModalCtrl', EditUserModalCtrl);

    EditUserModalCtrl.$inject = ['$scope', 'user', 'authSvc', '$modalInstance'];

    function EditUserModalCtrl($scope, user, authSvc, $modalInstance) {
        $scope.editUser = angular.copy(user);
        $scope.updateUser = updateUser;

        /////////////////////////////


        function updateUser(user) {
            authSvc.updateUser(user).then(function (res) {
                $modalInstance.close(user);
            }, function (res) {
                $modalInstance.dismiss();
            });
        }
    }
}());
