angular.module('app')
.controller('BudgetsController', ['$scope', '$state', '$stateParams', 'budgetsService', 'authService',
    function ($scope, $state, $stateParams, budgetsService, authService) {

        //SETUP ACCOUNT TIES TO HOUSEHOLD
        $scope.houseHold = authService.authentication.houseHold;
        $scope.CategoryId = "";
        $scope.Amount = "";


        //get Budgets
        $scope.getBudgets = function () {
            BudgetsService.getBudgets($scope.houseHold).then(function (data) {
                $scope.budgets = data;
            });
        }


        //create account
        $scope.createBudget = function createBudget() {
            $scope.budget = {
                HouseHold: $scope.houseHold,
                CategoryId: $scope.CategoryId,
                Amount: $scope.Amount,
            };
            budgetsService.createBudget($scope.budget).then(function (res) {
                $scope.Budget = res.data;
            });
        }

        $scope.getBudgets();

    }]);

