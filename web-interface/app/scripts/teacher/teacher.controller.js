app.controller('TeacherController', ['$scope', 'TeacherService', 'Cacher', function ($scope, TeacherService, Cacher) {
  $scope.title.text = 'Вчителі';

  $scope.teacherData = Cacher.teachers ? Cacher.teachers : [];
  $scope.configRequest = {};

  $scope.fetch = function () {
    TeacherService.getList().then(function (semesters) {
      var rawObjects = [];

      _.forEach(semesters, function (semesterItem) {
        rawObjects.push(semesterItem.plain());
      });

      $scope.teacherData = rawObjects;
      Cacher.teachers = rawObjects;
    });
  };

  $scope.onBlur = function (event) {
  };

  $scope.gridOptions = {
    data: 'teacherData'
  };
}]);