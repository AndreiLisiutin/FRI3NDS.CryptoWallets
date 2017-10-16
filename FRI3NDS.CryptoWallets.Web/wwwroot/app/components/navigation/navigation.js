'use strict';

angular.module('crypto.controllers')
	.config([
		'$stateProvider',
		function ($stateProvider) {
			$stateProvider
				.state('crypto.navigation', {
					abstract: true,
					templateUrl: 'app/components/navigation/navigation.html',
					controller: 'NavigationController'
				});
		}
	])
	.controller('NavigationController', [
		'$scope', '$state', '$timeout',
		function ($scope, $state, $timeout) {

		}
	]);