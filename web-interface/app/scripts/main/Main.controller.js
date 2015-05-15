app.controller('MainController', ['$scope', '_', function ($scope, _) {
    $scope.title = {};
    $scope.title.text = 'Навантаження';

    $scope.object = {
        'World': {
            type: 'object',
            age: 26
        },
        'Juan': {
            type: 'user',
            age: 25
        }
    };

    $scope.message = _.findKey($scope.object, {
        age: 25
    });
}]);