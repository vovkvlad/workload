app.controller('CathedraController', ['$scope', 'CathedraService', 'Cacher', function ($scope, CathedraService, Cacher) {
    $scope.title.text = 'Кафедри';

    $scope.cathedraData = Cacher.cathedra ? Cacher.cathedra : [];
    $scope.configRequest = {};

    $scope.fetch = function () {
        CathedraService.getList().then(function (semesters) {
            var rawObjects = [];

            _.forEach(semesters, function (semesterItem) {
                rawObjects.push(semesterItem.plain());
            });

            $scope.cathedraData = rawObjects;
            Cacher.cathedra = rawObjects;
        });
    };

    $scope.onBlur = function (event) {
    };

    $scope.gridOptions = {
        data: 'cathedraData'
    };
}]);