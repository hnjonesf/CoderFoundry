var app = angular.module('app', [])
     

.controller('mainController', function ($scope) {
    $scope.phones = [
      {
          'name': 'Nexus S',
          'snippet': 'Fast just got faster with Nexus S.'
      },
      {
          'name': 'Motorola XOOM™ with Wi-Fi',
          'snippet': 'The Next, Next Generation tablet.'
      },
      {
          'name': 'MOTOROLA XOOM™',
          'snippet': 'The Next, Next Generation tablet.'
      },
            {
                'name': 'Jones Varooom™',
                'snippet': 'Best in class, futeristic, phone.'
            }
    ];
});