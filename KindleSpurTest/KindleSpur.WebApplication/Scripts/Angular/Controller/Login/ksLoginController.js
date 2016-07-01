/**
     * @auther : MKN
     * @date : 07/05/2016
     * @Purpose : login and Signup controller - Manage all data related to  login and signup page
     */
app.controller('ksLoginController', ['$scope', 'authentification', '$location', '$rootScope', '$state', '$stateParams', function ($scope, authentification, $location, $rootScope, $state, $stateParams) {
    console.error('login Page loaded Successfully');
    rootScope = $rootScope;
 	$scope.loginDetails = {
 	    emailAddress : '',
        password : ''
 	};
 	$scope.signupDetails = {
 	    FirstName : '',
 	    LastName : '',
 	    EmailAddress: '',
 	    password: '',
 	    confirmPassword : ''
 	};
 	console.error($stateParams);

 	$scope.emailValidate = true;
 	$scope.emailValidation = function () {
 	    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
 	    if ($scope.emailAddress.match(mailformat)) {
 	        $scope.emailValidate = true;
 	        console.error('validdate')
 	    } else {
 	        $scope.emailValidate = false;
 	    }


 	};



     /**
     * @auther : MKN
     * @date : 07/05/2016
     * @Purpose : success callback after successful login
     */
 	var _successLoginCallBack = function (iObject) {
 	    console.error('In _successCallBack', iObject);
 	    $rootScope.loggedDetail = iObject;
 	    $state.go('ksUserDashBoard');
 	};
 	var _successPasswordCallBack = function (iObj) {
 	    console.error('In _successCallBack');
 	    alert('Your password has been save successfully.Please login')
 	    $state.go('login');
 	};
 	
 	var _successCallBack = function (iObj) {
 	    console.error('In _successCallBack');
 	    $scope.signupDetails.FirstName = "";
 	    $scope.signupDetails.LastName = "";
 	    $scope.signupDetails.EmailAddress = "";
 	   
 	    alert('Verification Link is sent successfully. Please check your email account')
 	};
     /**
      * @auther : MKN
      * @date : 07/05/2016
      * @Purpose : failure callback  - don't do anything if user enter wrong credienal in system
      */
 	var _failureLoginCallBack = function (iObj) {
 	    console.error('In _failureCallBack');
 	    alert('Invalid Username or Password')
 	  //$state.go('login');
 	 //  $state.go('dashBoard');
 	  //  window.location = '/User/Login';
 	};
 	var _failurePasswordCallBack = function (iObj) {
 	    console.error('In _failurePasswordCallBack');
 	    alert('Your password has been save successfully.Please login')
 	    //$state.go('login');
 	    $state.go('login');
 	    //  window.location = '/User/Login';
 	};
 	
     /**
      * @auther : MKN
      * @date : 07/05/2016
      * @Purpose : signup function  - send data to auth factory to send data to server.
      */
 	$scope.loginClick = function () {
 	    $state.go('ksUserDashBoard');
        return
 	    if ($scope.loginDetails.emailAddress == '' || $scope.loginDetails.password == '') {
 	        alert('Please enter emailAddress or  Password')
 	        return
 	    }

 	    var _object = {
 	        EmailAddress: $scope.loginDetails.emailAddress,
 	        Password: $scope.loginDetails.password,
 	    }
 	    console.error(_object)
        
	    authentification.login({ signupObject: _object, successCallBack: _successLoginCallBack, failureCallBack: _failureLoginCallBack });
 	};
 
 	$scope.savePassword = function () {
 	    console.error($scope.signupDetails)
 	    if ($scope.signupDetails.password == '') {
 	        alert('Please enter Password')
 	        return
 	    }
 	    var _object = {
 	        Password: $scope.signupDetails.password
 	    }
 	    var _string = window.location.href;
 	    _object.userId = _string.split("passwordPrompt/")[1];

        console.error(_object)
 	    authentification.savePassword({ signupObject: _object, successCallBack: _successPasswordCallBack, failureCallBack: _failurePasswordCallBack });
 	}; 	
    
     /**
      * @auther : MKN
      * @date : 07/05/2016
      * @Purpose : signup function  - send data to auth factory to send data to server.
      */
 	$scope.signupClick = function () {
 	    if ($scope.signupDetails.FirstName == '') {
 	        if ($scope.signupDetails.LastName == '' && $scope.signupDetails.EmailAddress == '') {
 	            alert('Please enter First,last name and Email address')
 	        }else if ($scope.signupDetails.LastName == '') {
 	            alert('Please enter last name')
 	        } else if ($scope.signupDetails.EmailAddress == '') {
 	            alert('Please enter Email address')
 	        }
 	        return
 	    }else if($scope.signupDetails.LastName == ''){
 	         if ($scope.signupDetails.EmailAddress == '') {
 	             alert('Please enter last name and Email address')
 	         } else {
 	             alert('Please enter last name')
 	         }
 	         return
 	    } else if ($scope.signupDetails.EmailAddress == '') {
 	        alert('Please enter Email address')
 	        return
 	    }
 	        

 		var _object = {
 		    FirstName: $scope.signupDetails.FirstName,
 		    LastName: $scope.signupDetails.LastName,
 		    EmailAddress: $scope.signupDetails.EmailAddress,
 		}
 		authentification.signup({ signupObject: _object, successCallBack: _successCallBack, failureCallBack: _failureLoginCallBack });
 	};

 	$scope.getLinkedInData = function () {
 	   
 	    if (!$scope.hasOwnProperty("userprofile")) {
 	        IN.API.Profile("me").fields(
					["id", "firstName", "lastName", "pictureUrl",
							"publicProfileUrl", "email-address"]).result(function (result) {
							    console.error(result);
							    // set the model
							    $rootScope.$apply(function () {
							        var userprofile = result.values[0]
							        authentification.linkedInClick({ loginObject: userprofile, successCallBack: _successLoginCallBack, failureCallBack: _failureLoginCallBack });
							        //go to main
							        //  $location.path("/main");
							    });
							}).error(function (err) {
							    $scope.error = err;
							});
 	    }
 	};
    //logout and go to login screen
 	$scope.logoutLinkedIn = function () {
 	    //retrieve values from LinkedIn
 	    if(IN.User) IN.User.logout();
 	    delete $rootScope.userprofile;
 	    $rootScope.loggedUser = false;
 	    _failureLoginCallBack();
 	};
}])