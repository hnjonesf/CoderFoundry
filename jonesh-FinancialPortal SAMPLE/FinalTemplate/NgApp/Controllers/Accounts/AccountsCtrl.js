(function () {

    'use strict';

    angular.module('app').controller('AccountsCtrl', AccountsCtrl);

    AccountsCtrl.$inject = ['$scope', 'accountServices', '$modal', '$templateCache', '$state'];

    function AccountsCtrl($scope, accountServices, $modal, $templateCache, $state) {

        $scope.createAccount = createAccount;
        $scope.editAccount = editAccount;
        $scope.deleteAccount = deleteAccount;
        $scope.goToTransactions = goToTransactions;
        $scope.currentAccount = {};
        getAccounts();
        ///////////

        function getAccounts() {
            accountServices.getAccounts().then(function (res) {
                $scope.Accounts = res.data;
                console.info('GetAccount succeeded');
            }, function (res) {
                console.info('GetAccount failed');
            });
        }

        function createAccount() {

            var modalInstance = $modal.open({
                templateUrl: 'NgApp/Views/Accounts/CreateAccountModal.html',
                controller: 'CreateAccountModalCtrl'
            });

            modalInstance.result.then(function (createdAccount) {
                getAccounts();
            }, function () {
                //
            });
        }

        function editAccount(account) {
            var modalInstance = $modal.open({
                templateUrl: 'NgApp/Views/Accounts/EditAccountModal.html',
                controller: 'EditAccountModalCtrl',
                resolve: {
                    account: function () {
                        return account;
                    }
                }
            });

            modalInstance.result.then(
                function (selectedItem) {
                    getAccounts();
            }, function () {
                
            });
        }

        function deleteAccount(account) {
            var modalInstance = $modal.open({
                templateUrl: 'NgApp/Views/Accounts/DeleteAccountModal.html'
            });

            modalInstance.result.then(function () {
                accountServices.deleteAccount(account.id).then(function (res) {
                    getAccounts();
                    console.info('account deleted');
                });
            }, function () {
                //
            });
        }

        function goToTransactions(account) {
            $state.go('Transactions', { 'accountId': account.id });
        }

        $scope.loadAccount = function (account) {
            console.log(account);
            $scope.currentAccount = account;
        }





    }

}());
