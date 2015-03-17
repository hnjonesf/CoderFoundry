
angular.module('app')
.controller('MenuController', ['$scope', '$state', '$stateParams', 'authService', function ($scope, $state, $stateParams, authSvc) {
    $scope.authentication = authSvc.authentication;
    $scope.logout = function () {
        authSvc.logOut();
        $state.go('Login');
    }
}]);