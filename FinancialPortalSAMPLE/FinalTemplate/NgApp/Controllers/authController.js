'use strict';
angular.module('app').controller('authController', ['$scope', '$location', 'authSvc', function ($scope, $location, authSvc) {

    $scope.loginData = {
        username: "",
        password: ""
    };

    $scope.registration = {

        UserName: "",
        Name: "",
        Password: "",
        ConfirmedPassword: "",
        Email: ""
    };

    $scope.message = "";
    $scope.message2 = "";
    $scope.savedSuccessfully = false;
    $scope.auth = authSvc.authentication; 



    $scope.login = function () {

        authSvc.login($scope.loginData).then(function (response)
        {
            $scope.message = "You have successfully logged in.";
        },
         function (err) {
             $scope.message = err.error_description;
         });
        $scope.loginData.Password = null;
    };

    $scope.logout = function () {
        authSvc.logout();
        $scope.message = "You have successfully logged out";
    }

    $scope.signUp = function () {

        authSvc.register($scope.registration).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message2 = "You have successfully registered.  You can now log in";
            $scope.loginData = {
                username: $scope.registration.UserName,
                password: $scope.registration.Password
            };

            authSvc.login($scope.loginData);
            $scope.registration.Password = null;
            $scope.registration.ConfirmedPassword = null;
            $scope.loginData.Password = null;
            // clear pass

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message2 = "Failed to register user due to:" + errors.join(' ');
         });
    };

    //set data 
    authSvc.fillAuthData();
}]);