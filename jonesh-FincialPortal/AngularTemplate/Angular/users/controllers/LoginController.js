angular.module('app').controller('LoginController', ['authService', '$scope', '$timeout', '$state', function (authService, $scope, $timeout, $state) {

    this.model = {
        userName: '',
        password: ''
    }

    this.message = "Login to your account";
    this.isError = false;
    this.alter = '';

    this.login = function () {
        var scope = this;

        authService.login(this.model).then(function (response) {
            $state.go('Dashboard');
        },
         function (err) {
             scope.message = err.error_description;
             var timer = $timeout(function () {
                 $timeout.cancel(timer);
                 //Anything I need to do
                 scope.message = "Login to your account"
             }, 1000 * 2);
         });
    };
}]);