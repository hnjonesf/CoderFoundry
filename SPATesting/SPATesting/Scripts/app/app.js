var app = angular.module('app', ['ngRoute']);

app.config(function ($routeProvider) {

    $routeProvider

    .when('/', {
        templateUrl: 'pages/main.html',
        controller: 'MainController'
    })

    .when('/second', {
        templateUrl: 'pages/second.html',
        controller: 'SecondController'
    })

    .when('/second/:num', {
        templateUrl: 'pages/second.html',
        controller: 'SecondController'
    })

      .otherwise({
          redirectTo: '/'
      });

});

app.controller('MainController', ['$scope', function ($scope) {

    $scope.user = "Hugh";

}]);

app.controller('SecondController', ['$scope', '$routeParams',
    function ($scope, $routeParams) {

        $scope.num = $routeParams.num || 1;
    $scope.user = "Jones";

}]);