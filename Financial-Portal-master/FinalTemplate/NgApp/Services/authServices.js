'use strict';
angular.module('app').factory('authSvc', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {

    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        username: "",
        name: "",
        token: "",
        claims: {}
    };

    var _register = function (registration) {
        _logout();
        return $http.post('/api/authentication/register', registration).then(function (response) {
            return response;
        });

    };

    var _deserializeClaims = function (claimsString) {
        var claimsArray = eval(claimsString);
        var claimsDict = {};
        for (var i = 0; i < claimsArray.length; i++) {
            if (typeof claimsDict[claimsArray.ClaimType] === 'undefined')
                claimsDict[claimsArray[i].ClaimType] = [];
            claimsDict[claimsArray[i].ClaimType].push(claimsArray[i].ClaimValue);
        }
        return claimsDict;
    }

    var _login = function (loginData) {
        console.log(loginData);
        var data = "grant_type=password&UserName=" + loginData.username + '&Password=' + loginData.password;
        var deferred = $q.defer();
        $http.post('/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
            .success(function (response) {
                var claims = _deserializeClaims(response.claims);
                _authentication.isAuth = true;
                _authentication.username = claims['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'][0];
                _authentication.name = claims['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname'][0];
                _authentication.claims = claims;
                _authentication.token = response.access_token;
                localStorageService.set('authorizationData', _authentication);
                deferred.resolve(response);

            }).error(function (err, status) {
                _logout();
                deferred.reject(err);
            });
        return deferred.promise;
    };

    var _logout = function () {
        localStorageService.remove('authorizationData');

        _authentication.isAuth = false;
        _authentication.username = "";
        _authentication.name = "";
        _authentication.claims = null;
        _authentication.token = "";

    };

    var _fillAuthData = function () {

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.username = authData.claims['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'][0];
            _authentication.names = authData.claims['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname'][0];
            _authentication.claims = authData.claims;
            _authentication.token = authData.token;
        }
    };

    var _getUser = function () {
        return $http.get('api/authentication/GetUser');
    };

    var _updateUser = function (editUser) {
        return $http.put('api/authentication/EditUser', editUser);
    };

    authServiceFactory.register = _register;
    authServiceFactory.login = _login;
    authServiceFactory.logout = _logout;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;
    authServiceFactory.getUser = _getUser;
    authServiceFactory.updateUser = _updateUser;

    return authServiceFactory;

}]);