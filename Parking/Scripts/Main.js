$(document).ready(function () {
    $('#inpPN').keyup(function () {
        if ($('#inpPN').val() != '') {
            $('#divSVC').show();
        } else {
            $('#divSVC').hide();
        }
    });

    var current = angular.module('AppMain', []);

    current.controller('AdminController', ['$scope', function ($scope) {
        $scope.currentPageName = window.location.pathname;
    }]);
});







