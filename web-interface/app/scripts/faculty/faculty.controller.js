app.controller('FacultyController', ['$scope', 'FacultyService', 'Cacher', 'RawInfoRetriever',
    function ($scope, FacultyService, Cacher, RawInfoRetriever) {

        $scope.title.text = 'Факультети';
        $scope.Data = Cacher.faculty ? Cacher.faculty : [];
        $scope.configRequest = {};

        $scope.fetch = function () {
            if ($scope.configRequest.facultyId) {
                FacultyService.getOne($scope.configRequest.facultyId).then(function (data) {
                    $scope.Data = RawInfoRetriever(data);
                    Cacher.faculty = $scope.Data;
                });
            } else if ($scope.configRequest.facultyName) {
                FacultyService.getByName($scope.configRequest.facultyName).then(function (data) {
                    $scope.Data = RawInfoRetriever(data);
                    Cacher.faculty = $scope.Data;
                });
            } else {
                FacultyService.getAll().then(function (data) {
                    $scope.Data = RawInfoRetriever(data);
                    Cacher.faculty = $scope.Data;
                });
            }
        };

        $scope.onBlur = function (event) {
        };

        $scope.gridOptions = {
            data: 'Data'
        };
    }]);