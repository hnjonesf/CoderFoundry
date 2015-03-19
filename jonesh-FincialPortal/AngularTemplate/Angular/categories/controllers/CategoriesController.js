angular.module('app')
        .controller('CategoriesController', ['$scope', '$state', '$stateParams', function ($scope, $state, $stateParams) {

            //SETUP Category TIES TO HOUSEHOLD
            $scope.houseHold = authService.authentication.houseHold;
            $scope.categories = [];

            //get accounts
            $scope.getCategories = function () {
                accountsService.getCategories($scope.houseHold).then(function (data) {
                    $scope.accounts = data;
                });
            }

            $scope.getCategories();

        }]);
