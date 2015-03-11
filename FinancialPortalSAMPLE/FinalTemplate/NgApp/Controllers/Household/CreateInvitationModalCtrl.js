(function () {
    'use strict';

    angular.module('app')
        .controller('CreateInvitationModalCtrl', CreateInvitationModalCtrl);

    CreateInvitationModalCtrl.$inject = ['$scope', '$modalInstance', 'householdServices'];

    function CreateInvitationModalCtrl($scope, $modalInstance, householdServices) {

        $scope.createInvitation = createInvitation;
        $scope.newInvitation = {
            ToEmail: '',
        };

        /////////////////////

        function createInvitation() {
            householdServices.createInvitation($scope.newInvitation).then(function (res) {
                $modalInstance.close($scope.newInvitation);
            }, function (res) {
                $modalInstance.dismiss();
            });
        }

    }
}());
