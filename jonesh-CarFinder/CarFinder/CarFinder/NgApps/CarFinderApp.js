// module directive declaration
angular.module('CarFinderApp', []);

// controller declaration (DisplayController) for module
angular.module('CarFinderApp').controller(
    'DisplayController', ['$scope', '$http', function ($scope, $http) {
        //declare properties and initialize to null
        $scope.selected = {
            year: '',
            make: '',
            model: '',
            trim: '',
        }
    }])

// factory declaration for module--this provides the connectivity to the web API controllers and actons
angular.module('CarFinderApp')
    .factory('carSvc', ['$http', function ($http) {

        var factory = {};

        factory.getYears = function () {
            return $http.get('/api/years').then(function (response) {
                return response.data;
            });
        };

        factory.getMakes = function (year) {
            var options = { parms: { model_year: year } };
            return $http.get('/api/makes', options)
                .then(function (response) {
                    return resonse.data;
                });
        };

        factory.getModels = function (year, make) {
            var options = { parms: { model_year: year, make: make } };
            return $http.get('/api/models', options)
                .then(function (response) {
                    return resonse.data;
                });
        };

        factory.getTrim = function (year, make, model) {
            var options = { parms: { model_year: year, make: make, model: model } };
            return $http.get('/api/trim', options)
                .then(function ( response ) {
                    return resonse.data;
                } );
        };
        return factory;
    }]);

//directive declarations for module
angular.module('CarFinderApp')
    .directive('carFinder', ['carSvc', function (carSvc) {
        return {
            //define usage restrictions
            restrict: 'AEC',
            //bind scope variable and attributes
            scope: {
                selectedYear: '=year'
            },
            //define template
            templateUrl: '/NgApps/Templates/CarFinderDirectiveTemplate.html',
            //define all functional behavior for this directive
            link: function (scope, elem, attrs) {
                scope.years = [];
                scope.years = function () {
                    carSvc.getYears().then(function (data) {
                        scope.years = data;
                    });
                }
                //get going
                scope.years()
            }
        }
    }]);

