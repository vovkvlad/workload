app.config(function($stateProvider, $urlRouterProvider, RestangularProvider){
    $urlRouterProvider.otherwise('/home');

    $stateProvider
        .state('Teachers', {
            url: '/teachers',
            templateUrl: 'templates/teachers.html',
            controller: 'TeacherController'
        })
        .state('Semesters', {
            url: '/semesters',
            templateUrl: 'templates/semester.html',
            controller: 'SemesterController'
        })
        .state('Statistics', {
            url: '/statistics',
            templateUrl: 'templates/statistics.html',
            controller: 'StatisticsController'
        })
        .state('home', {
            url: '/home',
            template: '<p>Hello from home</p>'
        })
        .state('Faculty', {
            url: '/faculty',
            templateUrl: 'templates/faculty.html',
            controller: 'FacultyController'
        })
        .state('Cathedra', {
            url: '/cathedra',
            templateUrl: 'templates/cathedra.html',
            controller: 'CathedraController'
        })
        .state('AdministrativePost', {
            url: '/admpost',
            templateUrl: 'templates/admpost.html',
            controller: 'AdmpostController'
        })
        .state('Nagruzka', {
            url: '/nagruzkaall',
            templateUrl: 'templates/nagruzkaall.html',
            controller: 'NagruzkaController'
        });

    RestangularProvider.setBaseUrl('http://localhost:63974/api');
});