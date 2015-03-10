(function () {

    'use strict';

    angular.module('app').controller('HouseholdCtrl', HouseholdCtrl);

    HouseholdCtrl.$inject = ['$scope', 'householdServices', '$modal'];

    function HouseholdCtrl($scope, householdServices, $modal) {

        $scope.Household = {};
        $scope.createHousehold = createHousehold;
        $scope.inviteUser = inviteUser;
        $scope.editHousehold = editHousehold;
        getHousehold();
        getInvitations();
        ///////////

        function getHousehold() {
            householdServices.getUsers().then(function (res) {
                $scope.Household.Users = res.data;
                console.info('GetUsers succeeded');
            }, function (res) {
                console.info('GetUsers failed');
            });
        }

        function getInvitations() {
            householdServices.getInvitations().then(function (res) {
                $scope.Household.Invitations = res.data;
                console.info('GetInvitations succeeded');
            }, function (res) {
                console.info('GetInvitations failed');
            });
        }

        function createHousehold() {
            var modalInstance = $modal.open({
                templateUrl: 'NgApp/Views/Household/CreateHouseholdModal.html'
            });

            modalInstance.result.then(function () {
                householdServices.createHousehold().then(function () {
                    getHousehold();
                    console.info('Createhousehold succeeded');
                }, function () {
                    console.info('Createhousehold Failed');
                });
            });
        }

        function inviteUser() {
            var modalInstance = $modal.open({
                templateUrl: 'NgApp/Views/Household/CreateInvitationModal.html',
                controller: 'CreateInvitationModalCtrl'
            });

            modalInstance.result.then(function () {
                getInvitations();
            });
        }

        function editHousehold(invitation, accepted) {
            var editHouseholdObj = {
                FromEmail: invitation.fromEmail,
                Household: invitation.houseHold,
                Accepted: accepted,
                Id: invitation.id
            }
            householdServices.editHousehold(editHouseholdObj).then(function () {
                getInvitations();
                getHousehold();
                console.info('EditHousehole Succeeded');
            }, function () {
                console.info('EditHousehole Failed');
            });
        }


    }

}());

