angular.module('app')
.controller('EditBudgetController', ['$scope', '$state', '$stateParams', 'budgetsService', 'authService', 'budget',
    function ($scope, $state, $stateParams, budgetsService, authService, budget) {

        $scope.budget = budget;

        //edit or delete account
        $scope.editBudget = function editBudget() {
            budgetsService.editBudget($scope.budget).then(function (res) {
                $state.go('Budgets');
            });
        }

        //delete account
        $scope.deleteAccount = function deleteAccount() {
            budgetsService.deleteAccount($scope.budget.Id).then(function (res) {
                $state.go('Budgets');
            });
        }


    }]);

