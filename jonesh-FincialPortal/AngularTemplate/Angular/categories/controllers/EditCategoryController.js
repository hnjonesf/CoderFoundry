angular.module('app')
.controller('EditCategoryController', ['$scope', '$state', '$stateParams', 'categoriesService', 'authService', 'category',
    function ($scope, $state, $stateParams, categoriesService, authService, category) {

        $scope.category = category;

        //EDIT CATEGORY
        $scope.editCategory = function editCategory() {
            categoriesService.editCategory($scope.category).then(function (res) {
                $state.go('Categories');
            });
        }

        //delete account
        //TODO: IF CATEGORY BEING USED IN A BUDGET OR TRANSACTION, RETURN UNABLE TO DELETE MESSAGE.
        //TODO: GetCategoriesByHousehold == true.
        $scope.deleteCategory = function deleteCategory() {
            categoriesService.deleteCategory($scope.category.Id).then(function (res) {
                $state.go('Categories');
            });
        }


    }]);

