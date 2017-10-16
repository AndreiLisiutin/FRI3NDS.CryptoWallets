'use strict';

angular.module('crypto.controllers')
	.config([
		'$stateProvider',
		function ($stateProvider) {
			$stateProvider
				.state('crypto.navigation.about', {
					url: '/about',
					templateUrl: 'app/components/about/about.html',
					controller: 'AboutController'
				});
		}
	])
	.controller('AboutController', [
		'$scope', '$state', '$timeout',
		function ($scope, $state, $timeout) {

		}
	]);