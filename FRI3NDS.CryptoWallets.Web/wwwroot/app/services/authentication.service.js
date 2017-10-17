(function () {
	'use strict';

	angular
		.module('crypto.services')
		.factory('AuthenticationService', ['$resource', function ($resource) {
			return $resource('/api/Authentication/:id', null, {
				getToken: {
					url: '/api/Authentication/GetToken',
					method: 'POST',
					isArray: false
				},
                signUp: {
                    url: '/api/Authentication/SignUp',
                    method: 'POST',
					isArray: false
				},
                refreshToken: {
                    url: '/api/Authentication/RefreshToken',
                    method: 'POST',
					isArray: false
				},
				test: {
					url: '/api/Authentication/Test',
					method: 'GET',
					isArray: false
				}
			});
		}]);
})();

