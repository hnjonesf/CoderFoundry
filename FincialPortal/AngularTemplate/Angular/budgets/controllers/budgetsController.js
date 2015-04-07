angular.module('app')
.controller('BudgetsController', ['$scope', '$state', '$stateParams', 'categories', 'budgets',
    function ($scope, $state, $stateParams, categories, budgets) {
        $scope.CategoryId = "";
        $scope.Amount = "";
        $scope.categories = categories;
        $scope.budgets = budgets;

    }]);

