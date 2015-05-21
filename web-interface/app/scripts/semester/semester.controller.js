app.controller('SemesterController', ['$scope', 'SemestersService', 'Cacher', function ($scope, SemesterService, Cacher) {

    $scope.title.text = 'Семестри';
    $scope.semesterData = Cacher.semesters ? Cacher.semesters : [];
    $scope.configRequest = {};

    $scope.fetch = function () {
        SemesterService.getList().then(function (semesters) {
            var rawObjects = [];

            _.forEach(semesters, function (semesterItem) {
                 rawObjects.push(semesterItem.plain());
            });

            $scope.semesterData = rawObjects;
            Cacher.semesters = rawObjects;
            alert('fetched!');
        });
    };

    $scope.onBlur = function (event) {
    };

    $scope.gridOptions = {
        data: 'semesterData'
    };
}]);