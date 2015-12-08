/// <reference path="Templates/Home.html" />
//MODULE
var weatherApp = angular.module('weatherApp', ['ngRoute', 'ngResource','ngAutocomplete']);

//ROUTES
weatherApp.config(function ($routeProvider) {

    $routeProvider

    .when('/', {
        templateUrl: 'Templates/Home.html',
        controller: 'HomeController'
    })

    .when('/forecast', {
        templateUrl: 'Templates/Forecast.html',
        controller: 'ForecastController'
    })

    .when('/forecast/:days', {
        templateUrl: 'Templates/Forecast.html',
        controller: 'ForecastController'
    })
});


//SERVICES
weatherApp.service('CityService', function () {

    this.details = { formattedAddress: "" };
    this.city = "Greensboro, NC";

});

//CONTROLLER
weatherApp.controller('HomeController', ['$scope','CityService', function ($scope, CityService) {

    $scope.details = {};
    $scope.details = CityService.details;

    //$scope.city = CityService.city;
    $scope.$watch('details', function () {
        CityService.details = $scope.details;
    });

}]);

weatherApp.controller('ForecastController', ['$scope','$resource','$routeParams','CityService', function ($scope, $resource, $routeParams, CityService) {

    $scope.days = $routeParams.days || 2;
    //$scope.city = CityService.city;
    $scope.details = CityService.details;
    $scope.weatherAPI = $resource("http://api.openweathermap.org/data/2.5/forecast/daily?APPID=61afac79a1a17bc84c64cca82edfa662");
    $scope.weatherResult = $scope.weatherAPI.get({ q: $scope.details.formattedAddress, cnt: $scope.days });

    $scope.convertToFahrenheit = function (degK) { return Math.round((1.8 * (degK - 273)) + 32); }
    $scope.convertToDate = function (dt) { return new Date(dt); }

    //waiting to get google.developer access code for image lookup :)
    //get google image of forecast
    //$scope.googleImage = $resource("https://ajax.googleapis.com/ajax/services/search/images?v=1.0");
    //$scope.googleImageUrl = $scope.googleImage.get({ q: "cessna" });
    //q=searchString

}]);