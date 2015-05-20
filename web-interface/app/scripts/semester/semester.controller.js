app.controller('SemesterController', ['$scope', 'SemestersService', 'Cacher', function ($scope, SemesterService, Cacher) {

    $scope.title.text = 'Семестри';
    $scope.myData = Cacher.semesters ? Cacher.semesters : [];

    $scope.fetchSemesters = function () {
        SemesterService.getList().then(function (semesters) {
            var rawObjects = [];

            _.forEach(semesters, function (semesterItem) {
                 rawObjects.push(semesterItem.plain());
            });

            $scope.myData = rawObjects;
            Cacher.semesters = rawObjects;
            alert('fetched!');
        });
    };

    $scope.gridOptions = {
        data: 'myData'
    };
}]);