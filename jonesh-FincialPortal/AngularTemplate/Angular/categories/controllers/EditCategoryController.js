angular.module('app')
.controller('EditCategoryController', ['$scope', '$state', '$stateParams', 'categoriesService', 'authService', 'account',
    function ($scope, $state, $stateParams, categoriesService, authService, account) {

        $scope.account = category;

        //edit or delete account
        $scope.editCategory = function editCategory() {
            categoriesService.editCategory($scope.category).then(function (res) {
                $state.go('Categories');
            });
        }

        //delete account
        $scope.deleteCategory = function deleteCategory() {
            categoriesService.deleteCategory($scope.categroy.Id).then(function (res) {
                $state.go('Categories');
            });
        }


    }]);

