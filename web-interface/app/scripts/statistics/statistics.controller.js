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

        $scope.d3Data = null;
        $scope.d3DataPercentage = null;

        $scope.showLoader = false;
        $scope.showTable =  false;

        $scope.profEdgeMin = "250";
        $scope.profEdgeMax = "350";

        $scope.AsEdgeMin = "350";
        $scope.AsEdgeMax = "450";

        $scope.docEdgeMin = "300";
        $scope.docEdgeMax = "400";

        function RecieveCallBack (data) {
            $scope.Data = RawInfoRetriever(data);
            Cacher.statistics = $scope.Data;

            $scope.showLoader = false;

            var firstDiagram = [$scope.Data[0], $scope.Data[1], $scope.Data[2]];
            $scope.d3Data = prepareData(firstDiagram, false);
            $scope.d3DataProf = prepareDataSmall($scope.Data[2]);
            $scope.d3DataAs = prepareDataSmall($scope.Data[3]);
            $scope.d3DataDoc = prepareDataSmall($scope.Data[4]);
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
                console.log('error! date is not defined');
            }
        };

        $scope.onBlur = function (event) {
        };

        $scope.gridOptions = {
            data: 'Data[0]',
            enableColumnResize: true,
            showGroupPanel: true
            //plugins: [new ngGridFlexibleHeightPlugin()]
        };

        function prepareData (data, percentage) {
            var result = [];
            var ketString = '';
            var ranges = [0, 50, 100, 150, 200, 250, 300, 350, 400, 450, 500,550, 600, 650, 700, 750, 800, 850];
            if (data.length == 3) {
                _.forEach(data, function (Item) {
                    var midresult = [];

                    _.forEach(ranges, function (rangeItem, index, array) {
                        var counter = 0;
                        _.forEach(Item, function (dataItem) {
                            if (index != array.length-1){
                                if (_.inRange(dataItem.Sum, rangeItem, array[index + 1] -1)) {
                                    counter += 1;
                                }
                            }
                            else {
                                if (_.inRange(dataItem.Sum, array[index], Infinity)) {
                                    counter += 1;
                                }
                            }

                        });
                        if (index == array.length-1){
                            ketString = rangeItem.toString()  + '-' + array[index].toString()+'+';
                        }
                        else {
                            ketString = rangeItem.toString()  + '-' + array[index + 1].toString();
                        }
                        midresult.push({
                            range: ketString,
                            frequency: counter
                        });
                    });

                    result.push(midresult);
                });
            }
            else {
                _.forEach(ranges, function (rangeItem, index, array) {
                    var counter = 0;
                    _.forEach(data, function (dataItem) {
                        if (index != array.length-1){
                            if (_.inRange(dataItem.Sum, rangeItem, array[index + 1] -1)) {
                                counter += 1;
                            }
                        }
                        else {
                            if (_.inRange(dataItem.Sum, array[index], Infinity)) {
                                counter += 1;
                            }
                        }

                    });
                    if (index == array.length-1){
                        ketString = rangeItem.toString()  + '-' + array[index].toString()+'+';
                    }
                    else {
                        ketString = rangeItem.toString()  + '-' + array[index + 1].toString();
                    }
                    if (percentage) {
                        result.push({
                            range: ketString,
                            frequency: (counter/data.length)* 100
                        });
                    }
                    else {
                        result.push({
                            range: ketString,
                            frequency: counter
                        });
                    }
                });
            }
            return result;
        }

        function prepareDataSmall (data) {
            var result = [];
            var ketString = '';
            var start = 0;
            var end = 860;
            var ranges = [];
            do {
                ranges.push(start);
                start += 25;
            } while (start < end);
            _.forEach(ranges, function (rangeItem, index, array) {
                var counter = 0;
                var includedTeachers = [];
                _.forEach(data, function (dataItem) {
                    if (index != array.length-1){
                        var nextTreshold = array[index + 1];
                        if (array[index + 1] ==  $scope.profEdgeMax || array[index + 1] ==  $scope.AsEdgeMax || array[index + 1] ==  $scope.docEdgeMax) {
                            nextTreshold = array[index + 1] + 1;
                        }
                        if (_.inRange(dataItem.Sum, rangeItem, array[index + 1])) {
                            counter += 1;
                            includedTeachers.push({
                                id: dataItem.teacher,
                                sumIncluded: dataItem.Sum
                            });
                        }
                    }
                    else {
                        if (_.inRange(dataItem.Sum, array[index], Infinity)) {
                            counter += 1;
                            includedTeachers.push({
                                id: dataItem.teacher,
                                sumIncluded: dataItem.Sum
                            });
                        }
                    }

                });
                if (index == array.length-1){
                    ketString = rangeItem.toString()  /*+ '-' + array[index].toString()+'+'*/;
                }
                else {
                    ketString = rangeItem.toString()  /*+ '-' + array[index + 1].toString()*/;
                }
                result.push({
                    range: ketString,
                    frequency: counter,
                    teachers: includedTeachers
                });
            });
            return result;
        }

        $scope.$watch('showTable', function () {
            Resizer();
        });
}]);