var mainApp = angular.module("mainApp", []);


// controller declaration (DisplayController) for module
mainApp.controller('MaxController', ['$scope', 'EventService', function ($scope, EventService) {
    $scope.numbers = {
        maxn1: 0,
        maxn2: 0,
        maxn3: 0
    };
    $scope.MaxOfThree = function () {
        EventService.max($scope.numbers).then(function (data) {
            $scope.max3answer = data;
        });

    }
}]);

////// factory declaration for module--this provides the connectivity to the web API controllers and actons
mainApp.factory('EventService', ['$http', function ($http) {
    var factory = {};

    factory.max = function (numbers) {
        return $http.post('/api/values/max', numbers).then(function (response) {
            return response.data;
        });
    };

    factory.sum = function (sumNumbers) {
        return $http.post('/api/values/sum', sumNumbers).then(function (response) {
            return response.data;
        });
    };

    factory.multiply = function (numList) {
        return $http.post('/api/values/multiply', numList).then(function (response) {
            return response.data;
        });
    };

    factory.factorial = function (btnFactorial) {
        return $http.post('/api/values/factorial', btnFactorial)
            .then(function (response) {
            return response.data;
        });
    };

    factory.palindrome = function () {
        return $http.post('/api/values/palindrome', btnPalindrome)
            .then(function (response) {
                return response.data;
            });
    };

    return factory;


}]);

//// controller declaration (DisplayController) for module
mainApp.controller('SumController', ['$scope', 'EventService', function ($scope, EventService) {
    $scope.sumNumbers = {
        sumn1: 2,
        sumn2: 3,
        sumn3: 0
    };
    $scope.SumOfThree = function () {
        EventService.sum($scope.sumNumbers).then(function (data) {
            $scope.sum3answer = data;
        });

    }
}]);

mainApp.controller('MultiplyController', ['$scope', 'EventService', function ($scope, EventService) {
    $scope.numList = { num1: 1, num2: 2};
    $scope.Multiply = function() {
        EventService.multiply($scope.numList).then(function (data) {
            $scope.multiply3answer = data;
        });
    }
}]);

mainApp.controller('FactorialController', ['$scope', 'EventService', function ($scope, EventService) {
        $scope.factorial = function () {
            EventService.factorial($scope.btnFactorial).then(function (data) {
                console.log($scope.btnFactorial);
            $scope.factorialAnswer = data;
        });
    }
}]);

mainApp.controller('PalindromeController', ['$scope', 'EventService', function ($scope, EventService) {
    $scope.palindrome = function () {
        EventService.palindrome($scope.btnPalindrome).then(function (data) {
            $scope.answerPalindrome = data;
        });
    }
}]);



























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
