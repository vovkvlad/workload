app.controller('SemesterController', ['$scope', 'SemestersService', 'Cacher', function ($scope, SemesterService, Cacher) {

    $scope.title.text = 'Семестри';
    $scope.semesterData = Cacher.semesters ? Cacher.semesters : [];
    $scope.configRequest = {};

    function RecieveInfo (info) {
        var rawObjects = [];

        _.forEach(info, function (infoItem) {
            infoItem.plain ? rawObjects.push(infoItem.plain()) : rawObjects.push(infoItem);
        });

        $scope.semesterData = rawObjects;
        Cacher.semesters = rawObjects;
    }

    $scope.fetch = function () {
        if (configRequest.semesterId) {
            SemesterService.getOneSemester(configRequest.semesterId).then(function (semesters) {
                RecieveInfo(semesters);
            });
        } else if (configRequest.year && configRequest.semesterNumber) {
            SemesterService.getYearAndSemester(configRequest.year, configRequest.semesterNumber).then(function (semesters) {
                RecieveInfo(semesters);
            });
        } else if (configRequest.year) {
            SemesterService.getYear(configRequest.year).then(function (semesters) {
                RecieveInfo(semesters);
            });
        } else if (configRequest.semesterNumber) {
            SemesterService.getSemesterPart(configRequest.semesterNumber).then(function (semesters) {
                RecieveInfo(semesters);
            });
        } else {
            SemesterService.getAllSemesters().then(function (semesters) {
                RecieveInfo(semesters);
            });
        }
       /* SemesterService.getAllSemesters().then(function (semesters) {
           RecieveInfo(semesters);
        });

        SemesterService.getYearAndSemester(1983, 2).then(function (semesters) {
            RecieveInfo(semesters);
        });*/
    };

    $scope.onBlur = function (event) {
    };

    $scope.gridOptions = {
        data: 'semesterData'
    };
}]);