angular.module('app')
        .controller('BudgetsController', ['$scope', '$state', '$stateParams', function ($scope, $state, $stateParams) {
            $scope.title = {
                budgettitle: "Budgets"
            }
        }
        ]);