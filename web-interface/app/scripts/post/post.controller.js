app.controller('PostController', ['$scope', 'PostService', 'Cacher', 'RawInfoRetriever', 'Resizer',
    function ($scope, PostService, Cacher, RawInfoRetriever, Resizer) {

        $scope.title.text = 'Посади викладачів';
        $scope.Data = Cacher.post ? Cacher.post : [];
        $scope.configRequest = {};
        $scope.showLoader = false;
        $scope.showTable = Cacher.post ? true : false;

        $scope.fetch = function () {
            $scope.showLoader = true;

            PostService.getAll().then(function (data) {
                $scope.Data = RawInfoRetriever(data);
                Cacher.post = $scope.Data;

                $scope.showLoader = false;
                $scope.showTable = true;

                Resizer();
            });
        };

        $scope.onBlur = function (event) {
        };

        $scope.gridOptions = {
            data: 'Data',
            enableColumnResize: true
        };
    }]);