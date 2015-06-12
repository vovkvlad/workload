app.controller('SemesterController', ['$scope', 'SemestersService', 'Cacher', 'RawInfoRetriever', 'Resizer',
    function ($scope, SemesterService, Cacher, RawInfoRetriever, Resizer) {

        $scope.title.text = 'Семестри';
        $scope.semesterData = Cacher.semesters ? Cacher.semesters : [];
        $scope.configRequest = {};

        $scope.showLoader = false;
        $scope.showTable = Cacher.semesters ? true : false;

        function RecieveCallBack (data) {
            $scope.semesterData = RawInfoRetriever(data);
            Cacher.semesters = $scope.semesterData;

            $scope.showLoader = false;
            $scope.showTable = true;

            Resizer();
        }

        $scope.fetch = function () {
            $scope.showLoader = true;

            if ($scope.configRequest.semesterId) {
                SemesterService.getOne($scope.configRequest.semesterId).then(function (data) {
                    RecieveCallBack(data);
                });
            } else if ($scope.configRequest.year && $scope.configRequest.semesterNumber) {
                SemesterService.getYearAndSemester($scope.configRequest.year, $scope.configRequest.semesterNumber).then(function (data) {
                    RecieveCallBack(data);
                });
            } else if ($scope.configRequest.year) {
                SemesterService.getYear($scope.configRequest.year).then(function (data) {
                    RecieveCallBack(data);
                });
            } else if ($scope.configRequest.semesterNumber) {
                SemesterService.getSemesterPart($scope.configRequest.semesterNumber).then(function (data) {
                    RecieveCallBack(data);
                });
            } else {
                SemesterService.getAll().then(function (data) {
                    RecieveCallBack(data);
                });
            }
        };

        $scope.onBlur = function (event) {
        };

        $scope.gridOptions = {
            data: 'semesterData',
            enableColumnResize: true
        };
    }]);