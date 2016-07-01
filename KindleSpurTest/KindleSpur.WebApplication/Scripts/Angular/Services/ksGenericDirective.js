app.directive('pwdCheck', [function () {
    return {
        require: 'ngModel',
        link: function (scope, elem, attrs, ctrl) {
            var firstPassword = '#' + attrs.pwCheck;
            elem.add(firstPassword).on('keyup', function () {
                scope.$apply(function () {
                    var v = elem.val()===$(firstPassword).val();
                    ctrl.$setValidity('pwmatch', v);
                });
            });
        }
    }
}]);
app.directive('focusMe', function($timeout, $parse) {
  return {
    scope: {
		      blur: '&',
		      setFocus : '='
    },
    //scope: true,   // optionally create a child scope
    link: function(scope, element, attrs) {
		console.error(scope.setFocus);
		if(element[0] && scope.setFocus) element[0].focus();
      		element.bind('blur', function() {
			 scope.$apply(function() {
				if ('undefined' !== typeof scope.blur) {            
				      scope.blur();
				}
			 });
      		});
    }
  };
});
