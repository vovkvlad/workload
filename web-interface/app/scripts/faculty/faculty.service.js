app.factory('FacultyService', function (Restangular) {
    var service =  Restangular.all('Faculty');

    return {
        getAll: service.getList,

        getOne: service.get,

        getByName: service.all('name').get

    };
});