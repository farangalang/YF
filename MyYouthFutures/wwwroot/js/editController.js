(function () {
    'use strict';

    angular.module('app')
        .controller('editController',
        function ($scope) {

            $scope.showSave = false;

                $scope.editMade = function(text, elem) {
                    alert("EDIT: text = " + text + " ELEMENT = :" + elem);
                }

            });

    //editController.$inject = ['$location'];

    //function editController($location) {
    //    /* jshint validthis:true */
    //    var vm = this;
    //    vm.title = 'editController';
    //    vm.showSave = false;


    //}
    //function editFunction(text, elem) {
    //    alert("edit" + text + " : " + elem);
    //}
})();
