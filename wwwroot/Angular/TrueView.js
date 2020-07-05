var appTrueView = angular.module('trueViewApplication', []);

appTrueView.controller('trueViewController', function ($scope, $http) {

	
	$scope.identityNo = "";
	$scope.cellphoneNo = "";
	$scope.Pars = "";
	$scope.cellphoneNo = "";
	$scope.cellphoneNo = "";
	$scope.cellphoneNo = "";

	//	Internal variables
	$scope.listIsVisible = false;
	$scope.filteredContacts = [];

	$scope.load = function () {
		$http.get('https://localhost:44364/Contacts/Create?search=test').then(function (response) {
			$scope.Model = response.data;
			console.log($scope.Model);
		}).catch(function (response) {
			console.log(response);
		});
	}

	$scope.filterIDNumbers = function ()
	{
		$scope.filteredContacts = _.filter($scope.Model, function (element) {
			return element.identityNo.includes($scope.identityNo);
		});
	}

	$scope.showList = function () {
		$scope.listIsVisible = true;
	}
	$scope.hideList = function ()
	{
		$scope.listIsVisible = false;
	}

	$scope.itemSelected = function (item)
	{
		$scope.identityNo = item.identityNo;
		$scope.cellphoneNo = item.cellphoneNo;
		$scope.emailAddress = item.emailAddress;
		$scope.listIsVisible = false;
	}

	$scope.load();
});