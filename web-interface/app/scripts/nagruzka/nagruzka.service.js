app.factory('NagruzkaService', function (Restangular) {
    var service =  Restangular.all('NagruzkaAll');

    return {
        getAll: service.getList,

        getOne: service.get,

        getYear: service.all('year').get,

        getTeacher: service.all('teacher').get,

        getFaculty: service.all('faculty').get,

        getBySemeterId: service.all('semester').get,

        getByName :service.all('name').get,

        getByYearName: function (year, name) {
            return service.one('year', year).one('name', name).get();
        },

        getBySemesterName: function (semesterId, name) {
            return service.one('semester', semesterId).one('name', name).get();
        },

        getByFacultySemeter: function (facultyId, semesterId) {
            return service.one('faculty', facultyId).one('semester', semesterId).get();
        },

        getByFacultyYear: function (facultyId, year) {
            return service.one('faculty', facultyId).one('year', year).get();
        },

        getByTeacherSemeter: function (teacherId, semesterId) {
            return service.one('teacher', teacherId).one('semester', semesterId).get();
        },

        getByTeacherYear: function (teacherId, year) {
            return service.one('teacher', facultyId).one('year', year).get();
        },

        getByFacultyKurs: function (facultyId, kursNumber) {
            return service.one('faculty', facultyId).one('kurs', kursNumber).get();
        },

        getByTeacherKurs: function (teacherId, kursNumber) {
            return service.one('teacher', teacherId).one('kurs', kursNumber).get();
        },

        getByFacultySemeterKurs: function (facultyId, semesterId, kursNumber) {
            return service.one('faculty', facultyId).one('semester', semesterId).one('kurs', kursNumber).get();
        },

        getByTeacherSemeterKurs: function (teacherId, semesterId, kursNumber) {
            return service.one('teacher', teacherId).one('semester', semesterId).one('kurs', kursNumber).get();
        }
    };
});