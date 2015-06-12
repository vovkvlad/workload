app.controller('NagruzkaController', ['$scope', 'NagruzkaService', 'Cacher', 'RawInfoRetriever', 'Resizer',
    function ($scope, NagruzkaService, Cacher, RawInfoRetriever, Resizer) {
        $scope.title.text = 'Навантаження';

        $scope.nagruzkaData = Cacher.nagruzka ? Cacher.nagruzka : [];
        $scope.configRequest = {};

        $scope.showLoader = false;
        $scope.showTable = Cacher.nagruzka ? true : false;

        function RecieveCallBack (data) {
            $scope.nagruzkaData = RawInfoRetriever(data);
            Cacher.nagruzka = $scope.nagruzkaData;

            $scope.showLoader = false;
            $scope.showTable = true;

            Resizer();
        }

        $scope.fetch = function () {
            $scope.showLoader = true;

            if ($scope.configRequest.nagruzkaId) {
                NagruzkaService.getOne($scope.configRequest.nagruzkaId).then(function (data) {
                    RecieveCallBack(data);
                });
            } else {
                //all teachers logic
                if ($scope.configRequest.teacherId) {
                    if ($scope.configRequest.semesterId) {
                        if ($scope.configRequest.kursId) {
                            NagruzkaService.getByTeacherSemeterKurs($scope.configRequest.teacherId, $scope.configRequest.semesterId, $scope.configRequest.kursId).then(function (data) {
                                RecieveCallBack(data);
                            });
                            return;
                        } else {
                            NagruzkaService.getByTeacherSemeter($scope.configRequest.teacherId, $scope.configRequest.semesterId).then(function (data) {
                                RecieveCallBack(data);
                            });
                            return;
                        }
                    } else if ($scope.configRequest.kursId) {
                        NagruzkaService.getByTeacherKurs($scope.configRequest.teacherId, $scope.configRequest.kursId).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    } else if ($scope.configRequest.yearId) {
                        NagruzkaService.getByTeacherYear($scope.configRequest.teacherId, $scope.configRequest.yearId).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    } else {
                        NagruzkaService.getTeacher($scope.configRequest.teacherId).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    }
                }
                //if faculty exists and all it's combination
                else if ($scope.configRequest.facultyId) {
                    if ($scope.configRequest.semesterId) {
                        if ($scope.configRequest.kursId) {
                            NagruzkaService.getByFacultySemeterKurs($scope.configRequest.facultyId, $scope.configRequest.semesterId, $scope.configRequest.kursId).then(function (data) {
                                RecieveCallBack(data);
                            });
                            return;
                        } else {
                            NagruzkaService.getByFacultySemeter($scope.configRequest.facultyId, $scope.configRequest.semesterId).then(function (data) {
                                RecieveCallBack(data);
                            });
                            return;
                        }
                    } else if ($scope.configRequest.kursId) {
                        NagruzkaService.getByFacultyKurs($scope.configRequest.facultyId, $scope.configRequest.kursId).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    } else if ($scope.configRequest.yearId) {
                        NagruzkaService.getByFacultyYear($scope.configRequest.facultyId, $scope.configRequest.yearId).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    } else {
                        NagruzkaService.getFaculty($scope.configRequest.facultyId).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    }
                }
                //year semester and name logic
                else if ($scope.configRequest.yearId) {
                    if ($scope.configRequest.courseName) {
                        NagruzkaService.getByYearName($scope.configRequest.yearId, $scope.configRequest.courseName).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    } else {
                        NagruzkaService.getYear($scope.configRequest.yearId).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    }
                } else if ($scope.configRequest.semesterId) {
                    if ($scope.configRequest.courseName) {
                        NagruzkaService.getBySemesterName($scope.configRequest.semesterId, $scope.configRequest.courseName).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    } else {
                        NagruzkaService.getBySemeterId($scope.configRequest.semesterId).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    }
                }

                NagruzkaService.getAll().then(function (data) {
                    RecieveCallBack(data);
                });
            }
        };

        $scope.onBlur = function (event) {
        };

        $scope.gridOptions = {
            data: 'nagruzkaData',
            enableColumnResize: true,
            showGroupPanel: true
            //plugins: [new ngGridFlexibleHeightPlugin()]
        };
    }]);