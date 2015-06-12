app.controller('StatisticsController', ['$scope', 'StatisticsService', 'Cacher', 'RawInfoRetriever', 'Resizer',
    function ($scope, StatisticsService, Cacher, RawInfoRetriever, Resizer) {
    $scope.title.text = 'Статистика';

        $scope.Data = Cacher.statistics ? Cacher.statistics : [];
        $scope.configRequest = {
            type: {
                lec: true,
                sem: true,
                lab: true,
                kons: true,
                exam: true,
                prac: true
            }
        };

        $scope.showLoader = false;
        $scope.showTable = Cacher.statistics ? true : false;

        function RecieveCallBack (data) {
            $scope.Data = RawInfoRetriever(data);
            Cacher.statistics = $scope.Data;

            $scope.showLoader = false;
            $scope.showTable = true;

            Resizer();
        }

        $scope.fetch = function () {
            $scope.showLoader = true;

            if ($scope.configRequest.yearId) {
                if ($scope.configRequest.cathedraId) {
                    if ($scope.configRequest.rate) {
                        StatisticsService.getByCathedraYearRatePost($scope.configRequest.cathedraId, $scope.configRequest.yearId, $scope.configRequest.rate,
                        $scope.configRequest.posId1, $scope.configRequest.posId2, $scope.configRequest.posId3).then(function (data) {
                            RecieveCallBack(data);
                        });
                    } else {
                        StatisticsService.getByCathedraYear($scope.configRequest.cathedraId, $scope.configRequest.yearId).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    }
                }
                //if faculty exists and all it's combination
                else if ($scope.configRequest.facultyId) {
                    if ($scope.configRequest.rate) {
                        StatisticsService.getByFacultyYearRatePost($scope.configRequest.facultyId, $scope.configRequest.yearId, $scope.configRequest.rate,
                            $scope.configRequest.posId1, $scope.configRequest.posId2, $scope.configRequest.posId3).then(function (data) {
                                RecieveCallBack(data);
                            });
                    } else {
                        StatisticsService.getByFacultyYear($scope.configRequest.facultyId, $scope.configRequest.yearId).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    }
                }
            } else if ($scope.configRequest.semesterId) {
                if ($scope.configRequest.cathedraId) {
                    if ($scope.configRequest.rate) {
                        StatisticsService.getByCathedraSemesterRatePost($scope.configRequest.cathedraId, $scope.configRequest.semesterId, $scope.configRequest.rate,
                            $scope.configRequest.posId1, $scope.configRequest.posId2, $scope.configRequest.posId3).then(function (data) {
                                RecieveCallBack(data);
                            });
                    } else {
                        StatisticsService.getByCathedraSemeter($scope.configRequest.cathedraId, $scope.configRequest.semesterId).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    }
                }
                //if faculty exists and all it's combination
                else if ($scope.configRequest.facultyId) {
                    if ($scope.configRequest.rate) {
                        StatisticsService.getByFacultySemesterRatePost($scope.configRequest.cathedraId, $scope.configRequest.semesterId, $scope.configRequest.rate,
                            $scope.configRequest.posId1, $scope.configRequest.posId2, $scope.configRequest.posId3).then(function (data) {
                                RecieveCallBack(data);
                            });
                    } else {
                        StatisticsService.getByFacultySemeter($scope.configRequest.facultyId, $scope.configRequest.semesterId).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    }
                }
            } else {
                console.log('error! date is not defined')
            }
            StatisticsService.getByFacultySemesterRatePost(1, 146).then(function (data) {
                RecieveCallBack(data)
            });

        };

        $scope.onBlur = function (event) {
        };

        $scope.gridOptions = {
            data: 'Data',
            enableColumnResize: true,
            showGroupPanel: true
            //plugins: [new ngGridFlexibleHeightPlugin()]
        }
}]);