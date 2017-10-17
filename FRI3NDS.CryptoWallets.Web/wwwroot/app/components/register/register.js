'use strict';

angular.module('crypto.controllers')
	.config([
		'$stateProvider',
		function ($stateProvider) {
			$stateProvider
				.state('crypto.register', {
					url: '/register',
					templateUrl: 'app/components/register/register.html',
                    controller: 'RegisterController'
				});
		}
	])
    .controller('RegisterController', [
		'$scope', '$state', '$timeout', '$localStorage', '$http', 'AuthenticationService',
		function ($scope, $state, $timeout, $localStorage, $http, AuthenticationService) {

			$scope.registerModel = {
				login: 'lisutin.andrey',
                password: 'lisutin.andrey',
                email: 'lisutin.andrey@gmail.com',
			};
			$http.defaults.headers.common.Language = 'ru';
			$scope.doRegister = function () {
                AuthenticationService.signUp($scope.registerModel).$promise
					.then(function (token) {
						alert('Успешно');
                        $localStorage.currentUser = { username: $scope.registerModel.login, token: token.token };
						$http.defaults.headers.common.Authorization = token.tokenType + ' ' + token.token;
					})
					.catch(function (error) {
						alert(error && error.data && error.data.message, 'Ошибка');
					});
			};
			$scope.doTest = function () {
				AuthenticationService.test().$promise
					.then(function (data) {
						alert("Вас зовут " + data.login);
					})
					.catch(function (error) {
						alert(error && error.data && error.data.message, 'Ошибка');
					});
			};
		}
	]);