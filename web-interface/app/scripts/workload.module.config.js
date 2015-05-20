app.config(function($stateProvider, $urlRouterProvider, RestangularProvider){
    $urlRouterProvider.otherwise('/home');

    $stateProvider
        .state('Teachers', {
            url: '/teachers',
            template: '<p>Hello from state1</p>',
            controller: 'TeacherController'
        })
        .state('Semesters', {
            url: '/semesters',
            templateUrl: 'templates/semester.html',
            controller: 'SemesterController'
        })
        .state('Statistics', {
            url: '/statistics',
            template: '<p>Hello from state1</p>',
            controller: 'StatisticsController'
        })
        .state('home', {
            url: '/home',
            template: '<p>Hello from home</p>'
        })
        .state('Faculty', {
            url: '/faculty',
            template: '<p>Hello from home</p>'
        })
        .state('Cathedra', {
            url: '/cathedra',
            template: '<p>Hello from home</p>'
        })
        .state('AdministrativePost', {
            url: '/admpost',
            template: '<p>Hello from home</p>'
        })
        .state('Nagruzka', {
            url: '/nagruzkaall',
            template: '<p>Hello from home</p>'
        });

    RestangularProvider.setBaseUrl('http://localhost:63974/api');
});