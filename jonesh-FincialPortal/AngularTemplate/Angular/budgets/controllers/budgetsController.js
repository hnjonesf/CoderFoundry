angular.module('app')
.controller('BudgetsController', ['$scope', '$state', '$stateParams', 'budgetsService', 'authService', 'categoriesService',
    function ($scope, $state, $stateParams, budgetsService, authService, categoriesService) {

        //SETUP ACCOUNT TIES TO HOUSEHOLD
        $scope.houseHold = authService.authentication.houseHold;
        $scope.CategoryId = "";
        $scope.Amount = "";


        //get Budgets
        $scope.getBudgets = function () {
            budgetsService.getBudgets($scope.houseHold).then(function (data) {
                $scope.budgets = data;
            });
        }


        //create account
        //get categories
        $scope.getCategories = function () {
            categoriesService.getCategories($scope.houseHold).then(function (data) {
                $scope.categories = data;
            });
        }

        $scope.getCategories();

        $scope.createBudget = function createBudget() {
        $scope.budget = {
            HouseHold: $scope.houseHold,
            Amount: $scope.Amount
        };
        budgetsService.createBudget($scope.budget).then(function (res) {
            $scope.budget = res.data;
            $state.go('Budgets');
        });
        }

        $scope.getBudgets();

    }]);

