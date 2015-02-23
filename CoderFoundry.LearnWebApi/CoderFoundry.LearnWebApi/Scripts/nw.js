angular.module('nw', ['ui.router'])
    .config(function ($stateProvider, $urlRouterProvider) {

        // For any unmatched url, redirect to /state1
        $urlRouterProvider.otherwise("/customers");

        // Now set up the states
        $stateProvider
            .state('customers', {
                url: "/customers",
                templateUrl: "customers.html",
                controller: 'CustomersController'
            })
            .state('createCustomer', {
                url: "/create",
                templateUrl: "edit.html",
                controller: 'EditCustomerController'
            })
            .state('editCustomer', {
                url: "/edit/:id",
                templateUrl: "edit.html",
                controller: 'EditCustomerController'
            })
            .state('deleteCustomer', {
                url: "/delete/:id",
                templateUrl: 'delete.html',
                controller: 'DeleteCustomerController'
            });
    })
    .factory('customers', function ($http, $q) {

        var cache = {},
            readCache = function () {
                var customers = [];

                for (var key in cache)
                    customers.push(cache[key]);

                return customers;
            },
            populateCache = function (customers) {

                if (!customers)
                    return;

                cache = {};

                for (var i = 0; i < customers.length; i++) {
                    var c = customers[i];
                    cache[c.customerID] = c;
                }
            };

        return {
            getCustomers: function (avoidCache) {

                if (!avoidCache) {
                    var custs = readCache();

                    if (custs.length)
                        return $q.when(readCache());
                }

                return $http.get('/api/northwind/customers')
                    .then(function (result) {
                        populateCache(result.data);

                        return readCache();
                    });
            },

            getCustomer: function (id, avoidCache) {

                if (!avoidCache) {
                    var customer = cache[id];

                    if (customer)
                        return $q.when(customer);
                }

                return $http.get('/api/northwind/customers/' + id)
                    .then(function (result) {
                        var cust = result.data;
                        return cache[cust.customerID] = cust;
                    });
            },

            createCustomer: function (newCustomer) {

                cache[newCustomer.customerID] = newCustomer;
                return $http.post('/api/northwind/customers', newCustomer);
            },

            updateCustomer: function (customer) {

                cache[customer.customerID] = customer;
                return $http.put('/api/northwind/customers', customer);
            },
            deleteCustomer: function (id) {
                delete cache[id];
                return $http.delete('/api/northwind/customers/' + id);
            }
        };
    })
    .controller('CustomersController', function ($scope, customers) {

        customers.getCustomers().then(function (data) {
            $scope.customers = data;
        });

    })
    .controller('DeleteCustomerController', function ($scope, $state, $stateParams, customers) {

        var custId = $stateParams.id;

        customers.getCustomer(custId).then(function (c) {
            $scope.customer = c;
        });

        $scope.confirmDelete = function() {
            customers.deleteCustomer(custId).then(function() {
                $state.go('customers');
            });
        };
        
    })
    .controller('EditCustomerController', function ($scope, $state, $stateParams, customers) {

        var custId = $stateParams.id;
        $scope.newCustomer = !custId;
        $scope.customer = {};

        if (!$scope.newCustomer) {
            customers.getCustomer(custId).then(function (c) {
                $scope.customer = angular.copy(c);
            });
        }

        $scope.save = function () {

            var promise = $scope.newCustomer
                ? customers.createCustomer($scope.customer)
                : customers.updateCustomer($scope.customer);

            promise.then(function () {
                $state.go('customers');
            });

        };


    });