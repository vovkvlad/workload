var app = angular.module('Workload', ['ui.router']);

app.constant('_', window._).run(function ($rootScope) {
    $rootScope._ = window._;
});