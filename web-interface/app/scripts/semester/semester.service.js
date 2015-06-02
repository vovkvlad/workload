app.factory('SemestersService', function (Restangular) {
    var service =  Restangular.all('Semesters');

    return {
        getAll: service.getList,

        getOne: service.get,

        getYear: service.all('year').get,

        getSemesterPart: service.all('semester').get,

        getYearAndSemester: function (yearId, semesterPart) {
            return service.one('year', yearId).one('semester', semesterPart).get();
        }
    };
});