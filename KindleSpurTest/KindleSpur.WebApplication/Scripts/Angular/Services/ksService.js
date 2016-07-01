app.factory('authentification', function ($http) {
     return {
         //$http.get('/someUrl', config).then(successCallback, errorCallback);
         //$http.post('/someUrl', data, config).then(successCallback, errorCallback);
        /**
          * @auther : MKN
          * @date : 07/05/2016
          * @Purpose : login function - send credienal to verify details
          */
         login: function (iObj) {
             console.error(iObj)
             $http.post('/User/LoginResult', iObj.signupObject).then(iObj.successCallBack, iObj.failureCallBack);
         },
         /**
          * @auther : MKN
          * @date : 07/05/2016
          * @Purpose : logout function - reset all data 
          */
         logout: function (iObj) {
             $http.get('/plateformLogout', iObj.signupObject).then(iObj.successCallBack, iObj.failureCallBack);
         },
         /**
          * @auther : MKN
          * @date : 07/05/2016
          * @Purpose : Signup click function - send credienal to verify details
          */
         signup: function (iObj) {
             console.error(iObj)
             $http.post('/User/Login',iObj.signupObject).then(iObj.successCallBack,iObj.failureCallBack);
         },

         savePassword: function (iObj) {
             console.error(iObj)
             $http.post('/User/SavePassword', iObj.signupObject).then(iObj.successCallBack, iObj.failureCallBack);
         },
         linkedInClick: function (iObj) {
             console.error(iObj)
             var _obj = {
                 FirstName: iObj.loginObject.firstName,
                 LastName: iObj.loginObject.lastName,
                 img: iObj.loginObject.pictureUrl,
                 publicUrl: iObj.loginObject.publicProfileUrl,
                 EmailAddress: iObj.loginObject.emailAddress,
                 IsExternalAuthentication: true
             }
             $http.post('/User/linkedIn', _obj).then(iObj.successCallBack, iObj.failureCallBack);
         },
         logout: function (iObj) {
             $http.post('/User/logout', iObj.loginObject).then(iObj.successCallBack, iObj.failureCallBack);
         },

     }
});
/**
  * @auther : MKN
  * @date : 10/06/2016
  * @Purpose : communication service with server
  */
app.factory('serverCommunication', function ($http) {
    return {
       
       
    }
});