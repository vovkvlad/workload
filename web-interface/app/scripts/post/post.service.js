app.factory('PostService', function (Restangular) {
  var service =  Restangular.all('Post');

  return {
    getAll: service.getList
  };

});