app.factory('Resizer', function ($timeout) {
    return function () {
        $timeout(function () {
            $(window).trigger('resize');
        }, 200);
    };
});
