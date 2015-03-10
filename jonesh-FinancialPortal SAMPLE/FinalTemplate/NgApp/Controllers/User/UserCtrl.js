(function () {

    'use strict';

    angular.module('app').controller('UserCtrl', UserCtrl);

    UserCtrl.$inject = ['$scope', 'authSvc', '$modal'];

    function UserCtrl($scope, authSvc, $modal) {

        $scope.User = {};
        $scope.editUser = editUser;
        getUser();
        ///////////

        function getUser() {
            authSvc.getUser().then(function (res) {
                $scope.User = res.data;
                console.info('GetUser succeeded');
            }, function (res) {
                console.info('GetUser failed');
            });
        }

        function editUser() {
            var modalInstance = $modal.open({
                templateUrl: 'NgApp/Views/User/EditUserModal.html',
                controller: 'EditUserModalCtrl',
                resolve: {
                    user: function () {
                        return $scope.User;
                    }
                }
            });

            modalInstance.result.then(
                function (selectedItem) {
                    getUser();
                }, function () {

                });
        }


    }

}());

