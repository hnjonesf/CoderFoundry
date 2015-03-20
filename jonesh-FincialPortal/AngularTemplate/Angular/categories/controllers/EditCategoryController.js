angular.module('app')
.controller('EditCategoryController', ['$scope', '$state', '$stateParams', 'categoriesService', 'authService', 'category',
    function ($scope, $state, $stateParams, categoriesService, authService, category) {

        $scope.category = category;

        //edit or delete account
        $scope.editCategory = function editCategory() {
            categoriesService.editCategory($scope.category).then(function (res) {
                $state.go('Categories');
            });
        }

        //delete account
        $scope.deleteCategory = function deleteCategory() {
            categoriesService.deleteCategory($scope.category.Id).then(function (res) {
                $state.go('Categories');
            });
        }


    }]);

