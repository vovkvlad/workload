app.config(function($stateProvider, $urlRouterProvider){
    $urlRouterProvider.otherwise('/home');

    $stateProvider
        .state('Teachers', {
            url: '/teachers',
            template: '<p>Hello from state1</p>',
            controller: 'TeacherController'
        })
        .state('Semesters', {
            url: '/semesters',
            template: '<p>Hello from state1</p>'
        })
        .state('Statistics', {
            url: '/statistics',
            template: '<p>Hello from state1</p>'})
        .state('home', {
            url: '/home',
            template: '<p>Hello from home</p>'
        });
});