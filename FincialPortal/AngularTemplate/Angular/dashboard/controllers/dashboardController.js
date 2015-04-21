angular.module('app')
        .controller('DashboardController', ['$scope', '$state', '$stateParams', '$filter', 'accountsService', 'authService', 'categoriesService', function ($scope, $state, $stateParams, $filter, accountsService, authService) {

            //ACCOUNT TO HOUSEHOLD
            $scope.houseHold = authService.authentication.houseHold;
            $scope.Name = "";
            $scope.Balance = "";
            $scope.ReconciledBalance = "";

            //get transaction counts for account
            $scope.getTransCount = function () {
                //plugged account id here to get working, will change logic to pull from id as pulling transactions
                accountsService.GetAcctTransCount(2)
                    .then(function (data) {
                        $scope.transCount = data;
                    });
            }

            /**
             * Options for Bar chart
             */
            $scope.barOptions = {
                scaleBeginAtZero: true,
                scaleShowGridLines: true,
                scaleGridLineColor: "rgba(0,0,0,.05)",
                scaleGridLineWidth: 1,
                barShowStroke: true,
                barStrokeWidth: 1,
                barValueSpacing: 5,
                barDatasetSpacing: 1,
            };

            /**
             * Data for Bar chart
             */
            $scope.barData = {
                labels: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
                datasets: [
                    {
                        label: "Actual Expenses",
                        fillColor: "rgba(44,44,44,0.5)",
                        strokeColor: "rgba(220,220,220,0.8)",
                        highlightFill: "rgba(220,220,220,0.75)",
                        highlightStroke: "rgba(220,220,220,1)",
                        data: [65, 59, 80, 81, 56, 55, 40, 58, 52, 51, 37, 59]
                    },
                    {
                        label: "Budget Expenses",
                        fillColor: "rgba(49,117,175,0.9)",
                        strokeColor: "rgba(98,203,49,0.8)",
                        highlightFill: "rgba(98,203,49,0.75)",
                        highlightStroke: "rgba(98,203,49,1)",
                        data: [28, 48, 40, 19, 86, 27, 90, 82, 45, 47, 82, 90]
                    }
                ]
            };

        }]);