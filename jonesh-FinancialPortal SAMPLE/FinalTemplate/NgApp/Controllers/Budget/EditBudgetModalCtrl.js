(function () {

    'use strict';

    angular.module('app')
        .controller('EditBudgetModalCtrl', EditBudgetModalCtrl);

    EditBudgetModalCtrl.$inject = ['$scope', 'budget', 'budgetServices', '$modalInstance'];

    function EditBudgetModalCtrl($scope, budget, budgetServices, $modalInstance) {
        $scope.editBudget = angular.copy(budget);
        $scope.updateBudget = updateBudget;

        /////////////////////////////


        function updateBudget(budget) {
            budgetServices.editBudget(budget).then(function (res) {
                $modalInstance.close(budget);
            }, function (res) {
                $modalInstance.dismiss();
            });
        }
    }
}());
