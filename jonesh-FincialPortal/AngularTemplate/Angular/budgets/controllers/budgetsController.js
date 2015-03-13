(function () {
    angular.module('app')
        // Path: /
        .controller('BudgetsController', ['$scope', '$state', '$stateParams' , function ($scope, $state, $stateParams) {
        }])
})();

/*SAMPLE CODE TO GET ME GOING
 * 
 * (function () {

    'use strict';

    angular.module('app').controller('BudgetCtrl', BudgetCtrl);

    BudgetCtrl.$inject = ['$scope', 'budgetServices','$modal'];

    function BudgetCtrl($scope, budgetServices, $modal) {

        $scope.Budget = {};
        $scope.editBudget = editBudget;
        getBudget();
        ///////////

        function getBudget() {
            budgetServices.getBudgets().then(function (res) {
                $scope.Budget = res.data;
                console.info('GetBudget succeeded');
            }, function (res) {
                console.info('GetBudget failed');
            });
        }

        function editBudget() {
            var modalInstance = $modal.open({
                templateUrl: 'NgApp/Views/Budget/EditBudgetModal.html',
                controller: 'EditBudgetModalCtrl',
                resolve: {
                    budget: function () {
                        return $scope.Budget;
                    }
                }
            });

            modalInstance.result.then(
                function (selectedItem) {
                    getBudget();
                }, function () {

                });
        }


    }

}());

 * 
 * 
 * 
 * 
 */