app.controller('FacultyController', ['$scope', 'FacultyService', 'Cacher', function ($scope, FacultyService, Cacher) {
    $scope.title.text = 'Факультети';

    $scope.facultyData = Cacher.faculty ? Cacher.faculty : [];
    $scope.configRequest = {};

    $scope.fetch = function () {
        NagruzkaService.getList().then(function (semesters) {
            var rawObjects = [];

            _.forEach(semesters, function (semesterItem) {
                rawObjects.push(semesterItem.plain());
            });

            $scope.facultyData = rawObjects;
            Cacher.faculty = rawObjects;
        });
    };

    $scope.onBlur = function (event) {
    };

    $scope.gridOptions = {
        data: 'facultyData'
    };
}]);