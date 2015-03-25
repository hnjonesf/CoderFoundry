angular.module('app')
.controller('EditBudgetController', ['$scope', '$state', '$stateParams', 'budgetsService', 'authService', 'budget', 'categoriesService',
    function ($scope, $state, $stateParams, budgetsService, authService, budget, categoriesService) {

        $scope.budget = budget;

        $scope.houseHold = authService.authentication.houseHold;
        $scope.category = {
            HouseHold: $scope.houseHold,
            CategoryId: null,
            Amount: 0.00
        };

        //get categories so you can pick FOREIGN KEY
        $scope.getCategories = function () {
            categoriesService.getCategories($scope.houseHold).then(function (data) {
                $scope.categories = data;
            });
        }

        $scope.getCategories();

        //edit or delete account
        $scope.editBudget = function editBudget() {
            budgetsService.editBudget($scope.budget).then(function (res) {
                $state.go('Budgets');
            });
        }

        //delete account
        $scope.deleteBudget = function deleteBudget() {
            budgetsService.deleteBudget($scope.budget.Id).then(function (res) {
                $state.go('Budgets');
            });
        }


    }]);

