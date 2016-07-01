
app.config(['$stateProvider', '$urlRouterProvider','$locationProvider',function($stateProvider, $urlRouterProvider,$locationProvider){
   
   

    var _string = window.location.href;
    if (_string.indexOf('PasswordPro') > -1) {
        console.error('1')
        var _userId = _string.split("=")[1];
        $urlRouterProvider.otherwise('passwordPrompt/' + _userId);
    } else {
        $urlRouterProvider.otherwise('login');
    }

    $locationProvider.html5Mode(true);
    $stateProvider
	.state('login', {
	    url: '/login',
	    templateUrl: '/User/Login',
	})
   
    .state('passwordPrompt', {
        url: '/password/:userId',
        templateUrl: '/User/PasswordPromp',
    })
    .state('forgotPassword', {
        url: '/forgotPassword/',
        templateUrl: '/User/ForgotPasswordEmail',
    })
	.state('ksUserDashBoard', {
	    url: '/ksUserDashBoard',
	    templateUrl: '/Home/ksUserDashBoard',
	})
  
}]);
