app.controller('CathedraController', ['$scope', 'CathedraService', 'Cacher', 'RawInfoRetriever', 'Resizer',
    function ($scope, CathedraService, Cacher, RawInfoRetriever, Resizer) {
        $scope.title.text = 'Кафедри';

        $scope.cathedraData = Cacher.cathedra ? Cacher.cathedra : [];
        $scope.configRequest = {};

        $scope.showLoader = false;
        $scope.showTable = Cacher.cathedra ? true : false;

        function RecieveCallBack (data) {
            $scope.cathedraData = RawInfoRetriever(data);
            Cacher.cathedra = $scope.cathedraData;

            $scope.showLoader = false;
            $scope.showTable = true;

            Resizer();
        }

        $scope.fetch = function () {
            $scope.showLoader = true;

            if ($scope.configRequest.cathedraId) {
                CathedraService.getOne($scope.configRequest.cathedraId).then(function (data) {
                    RecieveCallBack(data);
                });
            } else if ($scope.configRequest.cathedraName) {
                CathedraService.getByName($scope.configRequest.cathedraName).then(function (data) {
                    RecieveCallBack(data);
                });
            } else if ($scope.configRequest.facultyId) {
                CathedraService.getByFaculty($scope.configRequest.facultyId).then(function (data) {
                    RecieveCallBack(data);
                });
            } else {
                CathedraService.getAll().then(function (data) {
                    RecieveCallBack(data);
                });
            }
        };

        $scope.onBlur = function (event) {
        };

        $scope.gridOptions = {
            data: 'cathedraData',
            enableColumnResize: true
        };
    }]);