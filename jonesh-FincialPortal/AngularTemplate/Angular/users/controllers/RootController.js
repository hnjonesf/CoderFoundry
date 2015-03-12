app.controller('RootController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {
    $scope.logout = function () {
        authService.logOut();
        $location.path('/login');
    }
    $scope.isAuth = function () { return authService.authentication.isAuth; }
}]);