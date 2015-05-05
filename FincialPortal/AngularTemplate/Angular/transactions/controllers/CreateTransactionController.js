angular.module('app')
.controller('CreateTransactionController', ['$scope', '$state', '$stateParams', 'accountsService', 'categories',
    function ($scope, $state, $stateParams, accountsService,  categories) {

        $scope.categories = categories;
        $scope.accountId = $stateParams.accountId;

        $scope.transaction = {
            AccountId: $scope.accountId,
            Amount: 0.00,
            AbsAmount: 0.00,
            ReconciledAmount: 0.00,
            AbsReconciledAmount: 0.00,
            Date: null,
            Description: "",
            Updated: null,
            UpdatedByUserId: null,
            CategoryId: null
        };

        //CREATE TRANSACTION
        $scope.createTransaction = function createTransaction() {

            accountsService.createTransaction($scope.transaction).then(function () {
                $state.go('Transactions', {accountId: $scope.accountId});
            });
        }

    }]);

angular.module('app')
.controller('DatepickerController', function ($scope) {
    $scope.today = function() {
        $scope.transaction.Date = new Date();
    };
    $scope.today();

    $scope.clear = function () {
        $scope.transaction.Date = null;
    };

    // Disable weekend selection
    $scope.disabled = function(date, mode) {
        return ( mode === 'day' && ( date.getDay() === 0 || date.getDay() === 6 ) );
    };

    $scope.toggleMin = function() {
        $scope.minDate = $scope.minDate ? null : new Date();
    };
    $scope.toggleMin();

    $scope.open = function($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.opened = true;
    };

    $scope.dateOptions = {
        formatYear: 'yy',
        startingDay: 1
    };

    $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
    $scope.format = $scope.formats[0];
});

