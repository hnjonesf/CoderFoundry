angular.module('app')
.controller('CreateBudgetController', ['$scope', '$state', '$stateParams', 'budgetsService', 'authService', 'categoriesService',
    function ($scope, $state, $stateParams, budgetsService, authService, categoriesService) {

        $scope.houseHold = authService.authentication.houseHold;
        $scope.category = {
            HouseHold: $scope.houseHold,
            CategoryId: null,
            Amount: 0.00
        };

        //CREATE BUDGET
        //get categories so you can pick FOREIGN KEY
        $scope.getCategories = function () {
            categoriesService.getCategories($scope.houseHold).then(function (data) {
                $scope.categories = data;
            });
        }

        $scope.getCategories();

        $scope.createBudget = function createBudget() {
        $scope.budget = {
            HouseHold: $scope.houseHold,
            CategoryId: $scope.categoryId,
            Amount: $scope.Amount
        };
        budgetsService.createBudget($scope.budget).then(function (res) {
            $scope.budget = res.data;
            $state.go('Budgets');
        });
        }

    }]);

