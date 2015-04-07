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

        //NOT AVAILABLE DUE TO FK_CONSTRAINTS AND LACK OF TIME TO DO LOOKUP
        //delete CATEGORY
        $scope.deleteCategory = function deleteCategory() {
            categoriesService.deleteCategory($scope.category.Id).then(function (res) {
                $state.go('Categories');
            },
            function (res) {
                console.log('FK ERROR');
            });
        }

    }]);

