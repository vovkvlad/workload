app.factory('CathedraService', function (Restangular) {
    var service =  Restangular.all('Cathedra');
    return {
        getAll: service.getList,

        getOne: service.get,

        getByFaculty: service.all('faculty').get,

        getByName: service.all('name').get
    };
});