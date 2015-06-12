app.factory('StatisticsService', function (Restangular) {
    var service =  Restangular.all('Statistics');

    return {
        getAll: service.getList,

        getOne: service.get,

        getByFacultySemeter: function (facultyId, semesterId) {
            return service.one('faculty', facultyId).one('semester', semesterId).all('rate').getList();
        },

        getByFacultyYear: function (facultyId, year) {
            return service.one('faculty', facultyId).one('year', year).all('rate').getList();
        },

        getByCathedraSemeter: function (cathedra_id, semesterId) {
            return service.one('cathedra', cathedra_id).one('semester', semesterId).all('rate').getList();
        },

        getByCathedraYear: function (cathedra_id, year) {
            return service.one('cathedra', cathedra_id).one('year', year).all('rate').getList();
        },

        getByFacultySemesterRatePost: function (facultyId, semesterId, rate, post1, post2, post3) {
            return service.one('faculty', facultyId).one('semester', semesterId).one('rate', rate).one('post', post1).one('', post2).one('', post3).get();
        },

        getByFacultyYearRatePost: function (facultyId, year, rate, post1, post2, post3) {
            return service.one('faculty', facultyId).one('year', year).one('rate', rate).one('post', post1).one('', post2).one('', post3).get();
        },

        getByCathedraSemesterRatePost: function (cathedra_id, semesterId, rate, post1, post2, post3) {
            return service.one('cathedra', cathedra_id).one('semester', semesterId).one('rate', rate).one('post', post1).one('', post2).one('', post3).get();
        },

        getByCathedraYearRatePost: function (cathedra_id, year, rate, post1, post2, post3) {
            return service.one('cathedra', cathedra_id).one('year', year).one('rate', rate).one('post', post1).one('', post2).one('', post3).get();
        }
    }
});