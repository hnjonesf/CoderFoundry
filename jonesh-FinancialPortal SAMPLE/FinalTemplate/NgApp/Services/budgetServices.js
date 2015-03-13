(function () {

    'use strict';

    angular.module('app')
        .factory('budgetServices', budgetServices);

    budgetServices.$inject = ['$http'];

    function budgetServices($http) {
        return {
            getBudgets: getBudgets,
            editBudget: editBudget,
        }

        function getBudgets() {
            return $http.get('api/budgets/GetBudgets');
        }


        function editBudget(budget) {
            return $http.put('api/budgets/EditBudget', budget);
        }

    }
}());


