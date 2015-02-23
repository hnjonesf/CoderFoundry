//module
var mod = angular.module('mainApp', []);


//controller declaration (DisplayController) for module. We set the initial state of the object
mod.controller('eventController', ['$scope', '$http', 'eventModule', function ($scope, $http, eventModule)
{
    $scope.maxn1 = "",
    $scope.maxn2 = "",
    $scope.maxn3 = "",
    $scope.max3answer = "";

    $scope.MaxOfThree = function ()
    {
            eventModule.max($scope.maxn1, $scope.maxn2, $scope.maxn3).then(function (data)
            {
                $scope.max3answer = data;
            });
        
    }
}]);


//// factory declaration for module--this provides the connectivity to the web API controllers and actons
mod.factory('eventModule', ['$http', function ($http)
{
    var factory = {};

    factory.max = function (maxn1, maxn2, maxn3)
    {
        var options = { parms: { first: maxn1, second: maxn2, third: maxn3 } };
        return $http.post('/api/values/max', options).then(function (response)
        {
            return response.data;
        });
    };
    return factory;
}]);

    //    factory.sum = function (numbers) {
            
    //        return $http.get('/api/values/sum', options)
    //            .then(function (response) {
    //                return resonse.data;
    //            });
    //    };

    //    factory.multiply = function (numbers) {
    //        var options = { parms: { model_year: year, make: make } };
    //        return $http.get('/api/values/multiply', options)
    //            .then(function (response) {
    //                return resonse.data;
    //            });
    //    };

    //    factory.facNum = function (numberToFactor) {
    //        var options = { parms: { model_year: year, make: make, model: model } };
    //        return $http.get('/api/values/factorial', options)
    //            .then(function (response) {
    //                return resonse.data;
    //            });
    //    };

    //    factory.isPalindrome = function (value) {
    //        var options = { parms: { model_year: year, make: make, model: model } };
    //        return $http.get('/api/values/isPalindrome', options)
    //            .then(function (response) {
    //                return resonse.data;
    //            });
    //    };

    //},


////// factory declaration for module--this provides the connectivity to the web API controllers and actons
//mod.factory('eventModule', ['$http', function ($http) {
//        var factory = {};

//        factory.max1 = function (data) {
//            var options = { parms: { values: data } };
//            return $http.get('/api/values/max').then(function (response) {
//                return response.data;
//            });
//        };

//        factory.sum = function (numbers) {
            
//            return $http.get('/api/values/sum', options)
//                .then(function (response) {
//                    return resonse.data;
//                });
//        };

//        factory.multiply = function (numbers) {
//            var options = { parms: { model_year: year, make: make } };
//            return $http.get('/api/values/multiply', options)
//                .then(function (response) {
//                    return resonse.data;
//                });
//        };

//        factory.facNum = function (numberToFactor) {
//            var options = { parms: { model_year: year, make: make, model: model } };
//            return $http.get('/api/values/factorial', options)
//                .then(function (response) {
//                    return resonse.data;
//                });
//        };

//        factory.isPalindrome = function (value) {
//            var options = { parms: { model_year: year, make: make, model: model } };
//            return $http.get('/api/values/isPalindrome', options)
//                .then(function (response) {
//                    return resonse.data;
//                });
//        };

//    },

//]);

////directive declarations for module
//mod.directive('max1', ['eventModule', function (eventModule) {
//        return {
//            //define usage restrictions
//            restrict: 'AEC',
//            //bind scope variable and attributes
//            scope: {
//                inputMax: '=maxInput'
//            },
//            //define template
//            templateUrl: '/NgApps/Templates/Max.html',
//            //define all functional behavior for this directive
//            //calculate the max number in an array
//            link: function (scope, elem, attrs) {
//                scope.max1 = function () {
//                    eventModule.max1(scope.inputMax).then(function (data) {
//                        scope.maxOutput = data;
//                    });
//                }

//            }
//        }
//}]);



































///*Angular Modules take a name, best practice is lowerCamelCase, and a list of dependancies*/
///*added the second module as a dependancy */
//var mod = angular.module('mainApp', []);

//mod.controller(
//    'DisplayController', ['$scope', '$http', function ($scope, $http) {
//        //declare properties and initialize to null
//        $scope = {
//            maxInput: '',
//            sumInput: '',
//            multiplyInput: '',
//            factorialInput: '',
//            palindromeInput: '',
//        }
//    }])

//// factory declaration for module--this provides the connectivity to the web API controllers and actons
//mod.factory('eventModule', ['$http', function ($http) {
//        var factory = {};

//        factory.max1 = function (data) {
//            var options = { parms: { values: data } };
//            return $http.get('/api/values/max').then(function (response) {
//                return response.data;
//            });
//        };

//        factory.sum = function (numbers) {
            
//            return $http.get('/api/values/sum', options)
//                .then(function (response) {
//                    return resonse.data;
//                });
//        };

//        factory.multiply = function (numbers) {
//            var options = { parms: { model_year: year, make: make } };
//            return $http.get('/api/values/multiply', options)
//                .then(function (response) {
//                    return resonse.data;
//                });
//        };

//        factory.facNum = function (numberToFactor) {
//            var options = { parms: { model_year: year, make: make, model: model } };
//            return $http.get('/api/values/factorial', options)
//                .then(function (response) {
//                    return resonse.data;
//                });
//        };

//        factory.isPalindrome = function (value) {
//            var options = { parms: { model_year: year, make: make, model: model } };
//            return $http.get('/api/values/isPalindrome', options)
//                .then(function (response) {
//                    return resonse.data;
//                });
//        };

//    },

//    ]);


////directive declarations for module
//mod.directive('max1', ['eventModule', function (eventModule) {
//        return {
//            //define usage restrictions
//            restrict: 'AEC',
//            //bind scope variable and attributes
//            scope: {
//                inputMax: '=maxInput'
//            },
//            //define template
//            templateUrl: '/NgApps/Templates/Max.html',
//            //define all functional behavior for this directive
//            //calculate the max number in an array
//            link: function (scope, elem, attrs) {
//                scope.max1 = function () {
//                    eventModule.max1(scope.inputMax).then(function (data) {
//                        scope.maxOutput = data;
//                    });
//                }
                
//            }
//        }
//}]);
//mod.directive('sum', ['eventModule', function (eventModule) {
//    return {
//        //define usage restrictions
//        restrict: 'AEC',
//        //bind scope variable and attributes
//        scope: {
//            inputMax: '=inputSum'
//        },
//        //define template
//        templateUrl: '/NgApps/Templates/Sum.html',
//        //define all functional behavior for this directive
//        //sum an array
//        link: function (scope, elem, attrs) {
//            scope.sum = function () {
//                eventModule.sum(scope.maxInput).then(function (data) {
//                    scope.sumOutput = data;
//                });
//            }

//        }
//    }
//}]);

//mod.directive('multiply', ['eventModule', function (eventModule) {
//    return {
//        //define usage restrictions
//        restrict: 'AEC',
//        //bind scope variable and attributes
//        scope: {
//            inputMax: '=inputMultiply'
//        },
//        //define template
//        templateUrl: '/NgApps/Templates/Multiply.html',
//        //define all functional behavior for this directive
//        //multiply numbers in an array
//        link: function (scope, elem, attrs) {
//            scope.multiply = function () {
//                eventModule.multiply(scope.inputMax).then(function (data) {
//                    scope.multiplyOutput = data;
//                });
//            }

//        }
//    }
//}]);

//mod.directive('factorial', ['eventModule', function (eventModule) {
//    return {
//        //define usage restrictions
//        restrict: 'AEC',
//        //bind scope variable and attributes
//        scope: {
//            inputMax: '=inputFactorial'
//        },
//        //define template
//        templateUrl: '/NgApps/Templates/Factorial.html',
//        //define all functional behavior for this directive
//        link: function (scope, elem, attrs) {
//            scope.max1 = function () {
//                eventModule.factorial(scope.inputMax).then(function (data) {
//                    scope.factorialOutput = data;
//                });
//            }

//        }
//    }
//}]);

//mod.directive('palindrome', ['eventModule', function (eventModule) {
//    return {
//        //define usage restrictions
//        restrict: 'AEC',
//        //bind scope variable and attributes
//        scope: {
//            inputMax: '=inputPalindrome'
//        },
//        //define template
//        templateUrl: '/NgApps/Templates/Palindrome.html',
//        //define all functional behavior for this directive
//        link: function (scope, elem, attrs) {
//            scope.palindrome = function () {
//                eventModule.sum(scope.inputMax).then(function (data) {
//                    scope.palindromeOutput = data;
//                });
//            }

//        }
//    }
//}]);
