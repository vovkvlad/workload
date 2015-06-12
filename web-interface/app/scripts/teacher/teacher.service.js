app.factory('TeacherService', function (Restangular) {
    var service =  Restangular.all('Teacher');

    return {
        getAll: service.getList,

        getOne: service.get,

        getByPost: service.all('post').get,

        getByRate: service.all('rate').get,

        getByCathedra: service.all('cathedra').get,

        getByFaculty: service.all('faculty').get,

        getByFacultyPostRate: function (facultyId, postId, rateId) {
            return service.one('faculty', facultyId).one('post', postId).one('rate', rateId).get();
        },

        getByCathedraPostRate: function (cathedraId, postId, rateId) {
            return service.one('cathedra', cathedraId).one('post', postId).one('rate', rateId).get();
        },

        getByFacultyPost: function (facultyId, postId) {
            return service.one('faculty', facultyId).one('post', postId).get();
        },

        getByFacultyRate: function (facultyId, rateId) {
            return service.one('faculty', facultyId).one('rate', rateId).get();
        },

        getByCathedraPost: function (cathedraId, postId) {
            return service.one('cathedra', cathedraId).one('post', postId).get();
        },

        getByCathedraRate: function (cathedraId, rateId) {
            return service.one('cathedra', cathedraId).one('rate', rateId).get();
        },

        getByPostRate: function (postId, rateId) {
            return service.one('post', postId).one('rate', rateId).get();
        }

    };
});