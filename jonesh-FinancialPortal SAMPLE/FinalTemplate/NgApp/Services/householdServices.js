(function () {

    'use strict';

    angular.module('app')
        .factory('householdServices', householdServices);

    householdServices.$inject = ['$http'];

    function householdServices($http) {
        return {
            getUsers: getUsers,
            createHousehold: createHousehold,
            createInvitation: createInvitation,
            getInvitations: getInvitations,
            editHousehold: editHousehold
        }

        function getUsers() {
            return $http.get('api/households/GetUsers');
        }


        function createHousehold(household) {
            return $http.put('api/households/CreateHousehold');
        }

        function createInvitation(newInvitation) {
            return $http.post('api/households/CreateInvitation', newInvitation);
        }

        function getInvitations() {
            return $http.get('api/households/GetInvitations');
        }

        function editHousehold(invitation) {
            return $http.post('api/households/EditHousehold', invitation);
        }

    }
}());



