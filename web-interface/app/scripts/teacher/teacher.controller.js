app.controller('TeacherController', ['$scope', 'TeacherService', 'Cacher', 'RawInfoRetriever', 'Resizer',
    function ($scope, TeacherService, Cacher, RawInfoRetriever, Resizer) {

        $scope.title.text = 'Вчителі';

        $scope.teacherData = Cacher.teachers ? Cacher.teachers : [];
        $scope.configRequest = {};

        $scope.showLoader = false;
        $scope.showTable = Cacher.teachers ? true : false;

        function RecieveCallBack (data) {
            $scope.teacherData = RawInfoRetriever(data);
            Cacher.teachers = $scope.teacherData;

            $scope.showLoader = false;
            $scope.showTable = true;

            Resizer();
        }

        $scope.fetch = function () {
            $scope.showLoader = true;

            if ($scope.configRequest.teacherId) {
                TeacherService.getOne($scope.configRequest.teacherId).then(function (data) {
                    RecieveCallBack(data);
                });
            } else {
                //all cathedra logic
                if ($scope.configRequest.cathedraId) {
                    if ($scope.configRequest.posId) {
                        if ($scope.configRequest.rate) {
                            TeacherService.getByCathedraPostRate($scope.configRequest.cathedraId, $scope.configRequest.posId, $scope.configRequest.rate).then(function (data) {
                                RecieveCallBack(data);
                            });
                            return;
                        } else {
                            TeacherService.getByCathedraPost($scope.configRequest.cathedraId, $scope.configRequest.posId).then(function (data) {
                                RecieveCallBack(data);
                            });
                            return;
                        }
                    } else if ($scope.configRequest.rate) {
                        TeacherService.getByCathedraRate($scope.configRequest.facultyId, $scope.configRequest.rate).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    } else {
                        TeacherService.getByCathedra($scope.configRequest.facultyId).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    }
                }
                //if faculty exists and all it's combination
                else if ($scope.configRequest.facultyId) {
                    if ($scope.configRequest.posId) {
                        if ($scope.configRequest.rate) {
                            TeacherService.getByFacultyPostRate($scope.configRequest.facultyId, $scope.configRequest.posId, $scope.configRequest.rate).then(function (data) {
                                RecieveCallBack(data);
                            });
                            return;
                        } else {
                            TeacherService.getByFacultyPost($scope.configRequest.facultyId, $scope.configRequest.posId).then(function (data) {
                                RecieveCallBack(data);
                            });
                            return;
                        }
                    } else if ($scope.configRequest.rate) {
                        TeacherService.getByFacultyRate($scope.configRequest.facultyId, $scope.configRequest.rate).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    } else {
                        TeacherService.getByFaculty($scope.configRequest.facultyId).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    }
                }
                //post & rate logic
                else if ($scope.configRequest.posId) {
                    if ($scope.configRequest.rate) {
                        TeacherService.getByPostRate($scope.configRequest.posId, $scope.configRequest.rate).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    } else {
                        TeacherService.getByPost($scope.configRequest.posId).then(function (data) {
                            RecieveCallBack(data);
                        });
                        return;
                    }
                } else if ($scope.configRequest.rate) {
                    TeacherService.getByRate($scope.configRequest.rate).then(function (data) {
                        RecieveCallBack(data);
                    });
                    return;
                }

                TeacherService.getAll().then(function (data) {
                    RecieveCallBack(data);
                });
            }
        };


        $scope.onBlur = function (event) {
        };

        $scope.gridOptions = {
            data: 'teacherData',
            enableColumnResize: true
        };
    }]);