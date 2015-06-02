app.controller('SemesterController', ['$scope', 'SemestersService', 'Cacher', 'RawInfoRetriever',
    function ($scope, SemesterService, Cacher, RawInfoRetriever) {

    $scope.title.text = 'Семестри';
    $scope.semesterData = Cacher.semesters ? Cacher.semesters : [];
    $scope.configRequest = {};


    $scope.fetch = function () {
        if ($scope.configRequest.semesterId) {
            SemesterService.getOne($scope.configRequest.semesterId).then(function (semesters) {
                $scope.semesterData = RawInfoRetriever(semesters);
                Cacher.semesters = $scope.semesterData;
            });
        } else if ($scope.configRequest.year && $scope.configRequest.semesterNumber) {
            SemesterService.getYearAndSemester($scope.configRequest.year, $scope.configRequest.semesterNumber).then(function (semesters) {
                $scope.semesterData = RawInfoRetriever(semesters);
                Cacher.semesters = $scope.semesterData;
            });
        } else if ($scope.configRequest.year) {
            SemesterService.getYear($scope.configRequest.year).then(function (semesters) {
                $scope.semesterData = RawInfoRetriever(semesters);
                Cacher.semesters = $scope.semesterData;
            });
        } else if ($scope.configRequest.semesterNumber) {
            SemesterService.getSemesterPart($scope.configRequest.semesterNumber).then(function (semesters) {
                $scope.semesterData = RawInfoRetriever(semesters);
                Cacher.semesters = $scope.semesterData;
            });
        } else {
            SemesterService.getAll().then(function (semesters) {
                $scope.semesterData = RawInfoRetriever(semesters);
                Cacher.semesters = $scope.semesterData;
            });
        }
    };

    $scope.onBlur = function (event) {
    };

    $scope.gridOptions = {
        data: 'semesterData'
    };
}]);