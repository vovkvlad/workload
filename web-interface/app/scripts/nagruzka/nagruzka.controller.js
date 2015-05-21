app.controller('NagruzkaController', ['$scope', 'NagruzkaService', 'Cacher', function ($scope, NagruzkaService, Cacher) {
    $scope.title.text = 'Навантаження';

    $scope.nagruzkaData = Cacher.nagruzka ? Cacher.nagruzka : [];
    $scope.configRequest = {};

    $scope.fetch = function () {
        NagruzkaService.getList().then(function (semesters) {
            var rawObjects = [];

            _.forEach(semesters, function (semesterItem) {
                rawObjects.push(semesterItem.plain());
            });

            $scope.nagruzkaData = rawObjects;
            Cacher.nagruzka = rawObjects;
        });
    };

    $scope.onBlur = function (event) {
    };

    $scope.gridOptions = {
        data: 'nagruzkaData'
    };
}]);