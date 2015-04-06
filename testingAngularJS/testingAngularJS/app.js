var myApp = angular.module('myApp', []);

myApp.controller('mainController', ['$scope', '$filter', '$timeout', function($scope, $filter, $timeout) {
    
    $scope.userName = '';
    
    $scope.lowercasehandle = function() {
        return $filter('lowercase')($scope.userName);
    };

    $scope.uppercase = function () { return $filter('uppercase')($scope.userName) };
    
    //$scope.userName = "Hugh Jones";

    
}]);

myApp.service('cardService', ['$scope']);
