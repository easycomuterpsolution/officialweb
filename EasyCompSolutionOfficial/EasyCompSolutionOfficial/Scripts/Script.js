/// <reference path="../node_modules/angular/angular.min.js" />
/// <reference path="../node_modules/angular-material/angular-material.min.js" />

//'ngMaterial'
angular.module('buttonsDemoBasic', ['ngMaterial'])
.controller('AppCtrl', function ($scope) {
    $scope.title1 = 'Button';
    $scope.title4 = 'Warn';
    $scope.isDisabled = true;
    $scope.googleUrl = 'http://google.com';
});