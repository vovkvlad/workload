app.config(function($stateProvider, $urlRouterProvider){
    $urlRouterProvider.otherwise('/home');

    $stateProvider
        .state('state1', {
            url: '/state1',
            template: '<p>Hello from state1</p>'
        })
        .state('state2', {
            url: '/state2',
            template: '<p>Hello from state1</p>'
        })
        .state('state3', {url: '/state3',
            template: '<p>Hello from state1</p>'})
        .state('home', {
            url: '/home',
            template: '<p>Hello from home</p>'
        });
});