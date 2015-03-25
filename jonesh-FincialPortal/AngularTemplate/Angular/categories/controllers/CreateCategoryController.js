angular.module('app')
.controller('CreateCategoryController', ['$scope', '$state', '$stateParams', 'categoriesService', 'authService',
    function ($scope, $state, $stateParams, categoriesService, authService) {

        $scope.houseHold = authService.authentication.houseHold;
        $scope.category = {
            HouseHold: $scope.houseHold,
            Name: ""
        };

        //CREATE CATEGORY
        $scope.createCategory = function createCategory() {

            categoriesService.createCategory($scope.category).then(function () {
                $state.go('Categories');
            });
        }

    }]);

