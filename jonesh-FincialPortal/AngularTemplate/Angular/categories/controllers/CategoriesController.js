angular.module('app')
.controller('CategoriesController', ['$scope', '$state', '$stateParams', 'categoriesService', 'authService',
    function ($scope, $state, $stateParams, categoriesService, authService) {

        //SETUP ACCOUNT TIES TO HOUSEHOLD
        $scope.houseHold = authService.authentication.houseHold;
        $scope.Name = "";


        //get accounts
        $scope.getCategories = function () {
            accountsService.getCategories($scope.houseHold).then(function (data) {
                $scope.categories = data;
            });
        }


        //create account
        $scope.createCategory = function createCategory() {
            $scope.category = {
                HouseHold: $scope.houseHold,
                Name: $scope.Name
            };
            categoriesService.createCategory($scope.category).then(function (res) {
                $scope.category = res.data;
            });
        }

        $scope.getCategory();

    }]);

