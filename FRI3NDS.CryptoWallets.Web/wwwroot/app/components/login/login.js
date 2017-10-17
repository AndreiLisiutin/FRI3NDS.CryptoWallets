'use strict';

angular.module('crypto.controllers')
	.config([
		'$stateProvider',
		function ($stateProvider) {
			$stateProvider
				.state('crypto.login', {
					url: '/login',
					templateUrl: 'app/components/login/login.html',
					controller: 'LoginController'
				});
		}
	])
	.controller('LoginController', [
		'$scope', '$state', '$timeout', '$localStorage', '$http', 'AuthenticationService',
		function ($scope, $state, $timeout, $localStorage, $http, AuthenticationService) {

			$scope.loginModel = {
				login: 'lisutin.andrey',
				password: 'lisutin.andrey'
			};
			$http.defaults.headers.common.Language = 'ru';
			$scope.doLogin = function () {
				AuthenticationService.getToken($scope.loginModel).$promise
					.then(function (token) {
						alert('Успешно');
						$localStorage.currentUser = { username: $scope.loginModel.login, token: token.token };
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


			let connection = new signalR.HubConnection('/chat', { qs: { SessionId: '123' } });
			debugger;

			connection.on('Send', data => {
				console.log(data);
			});

			connection.start()
				.then(() => connection.invoke('Send', 'Hello'));
			
		}
	]);