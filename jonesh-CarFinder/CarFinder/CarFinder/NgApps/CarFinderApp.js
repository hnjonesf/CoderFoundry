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
            var options = { params: { year: year } };
            return $http.get('/api/makes', options)
                .then(function (response) {
                    return response.data;
                });
        };

        factory.getModels = function (year, make) {
            var options = { params: { year: year, make: make } };
            return $http.get('/api/models', options)
                .then(function (response) {
                    return response.data;
                });
        };

        factory.getTrims = function (year, make, model) {
            var options = { params: { year: year, make: make, model: model } };
            return $http.get('/api/trims', options)
                .then(function ( response ) {
                    return response.data;
                });
        };

        factory.getCars = function (year, make, model, trim) {
            var options = { params: { year: year, make: make, model: model, trim: trim } };
            return $http.get('/api/cars', options)
            .then(function (response) {
                return response.data;
            });
        };

        factory.getCarPhotoUrl = function (styleid) {
            var options = { params: { styleid: styleid } };
            return $http.get('https://api.edmunds.com/v1/api/vehiclephoto/service/findphotosbystyleid?styleId={styleid}&fmt=json&api_key=3v7dznfksaxqff35aw64sp9y', options)
            .then(function (response) {
                return response.data;
            });
        };

        factory.getCarPhotos = function (styleid) {
            var options = { params: { styleid: styleid } };
            return $http.get('https://api.edmunds.com/v1/api/vehiclephoto/service/findphotosbystyleid?styleId={styleid}&fmt=json&api_key=3v7dznfksaxqff35aw64sp9y', options)
            .then(function (response) {
                return response.data;
            });
        };

        factory.getCarPhotosId = function ( make, model, year) {
            var options = { params: { make: make, model: model, year: year } };
            return $http.get('https://api.edmunds.com/api/vehicle/v2/{make}/{model}/{year}/styles?fmt=json&api_key=3v7dznfksaxqff35aw64sp9y', options)
            .then(function (response) {
                return response.data;
            });
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
                selectedYear: '=year',
                selectedMake: '=make',
                selectedModel: '=model',
                selectedTrim: '=trim'
            },
            //define template
            templateUrl: '/NgApps/Templates/CarFinderDirectiveTemplate.html',
            //define all functional behavior for this directive
            link: function (scope, elem, attrs) {
                scope.years = [];
                scope.makes = [];
                scope.models = [];
                scope.trims = [];
                scope.selectedYear = "";
                scope.selectedMake = "";
                scope.selectedModel = "";
                scope.selectedTrim = "";


                scope.getYears = function () {
                    carSvc.getYears().then(function (data) {
                        scope.years = data;
                    });
                }

                scope.getMakes = function () {
                    carSvc.getMakes(scope.selectedYear).then(function (data) {
                        scope.makes = data;
                    });
                }

                scope.getModels = function () {
                    carSvc.getModels(scope.selectedYear, scope.selectedMake).then(function (data) {
                        scope.models = data;
                    });
                }

                scope.getTrims = function () {
                    carSvc.getTrims(scope.selectedYear, scope.selectedMake, scope.selectedModel).then(function (data) {
                        scope.trims = data;
                    });
                }

                scope.getCars = function () {
                    carSvc.getCars(scope.selectedYear, scope.selectedMake, scope.selectedModel, scope.selectedTrim).then(function (data) {
                        console.log(data);
                        scope.cars = data;
                    });
                }

                scope.getCarPhotoUrl = function () {
                    carSvc.getCarPhotoUrl(scope.carPhotoId).then(function (data) {
                        console.log(data);
                        scope.carPhotoUrl = data;
                    });
                }

                scope.getCarPhotos = function () {
                    carSvc.getCarPhotos(scope.styleId).then(function (data) {
                        console.log(data);
                        scope.carPhotoId = data;
                    });
                }

                scope.getCarPhotosId = function () {
                    carSvc.getCarPhotosId(scope.selectedMake, scope.selectedModel, scope.selectedYear).then(function (data) {
                        console.log(data);
                        scope.styleId = data.styles[0].id;
                    });
                }

                //get going
                scope.getYears()

            }
        }
    }]);

