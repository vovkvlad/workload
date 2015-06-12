app.controller('FacultyController', ['$scope', 'FacultyService', 'Cacher', 'RawInfoRetriever', 'Resizer',
    function ($scope, FacultyService, Cacher, RawInfoRetriever, Resizer) {

        $scope.title.text = 'Факультети';
        $scope.Data = Cacher.faculty ? Cacher.faculty : [];
        $scope.configRequest = {};
        $scope.showLoader = false;
        $scope.showTable = Cacher.faculty ? true : false;

        function RecieveCallBack (data) {
            $scope.Data = RawInfoRetriever(data);
            Cacher.faculty = $scope.Data;

            $scope.showLoader = false;
            $scope.showTable = true;

            Resizer();
        }

        $scope.fetch = function () {
            $scope.showLoader = true;

            if ($scope.configRequest.facultyId) {
                FacultyService.getOne($scope.configRequest.facultyId).then(function (data) {
                    RecieveCallBack(data);
                });
            } else if ($scope.configRequest.facultyName) {
                FacultyService.getByName($scope.configRequest.facultyName).then(function (data) {
                    RecieveCallBack(data);
                });
            } else {
                FacultyService.getAll().then(function (data) {
                    RecieveCallBack(data);
                });
            }
        };

        $scope.onBlur = function (event) {
        };

        $scope.gridOptions = {
            data: 'Data',
            enableColumnResize: true
        };
    }]);