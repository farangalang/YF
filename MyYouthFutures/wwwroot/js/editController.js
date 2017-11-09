(function () {
    'use strict';

    angular
        .module('app')
        .config(function (contentEditableProvider) {

            contentEditableProvider.configure({
                singleline: true, // single line for all elements
                focusSelect: false
        });
        })
        .controller('editController', editController, editFunction());

    editController.$inject = ['$location'];

    function editController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'editController';
        vm.showSave = false;


    }
    function editFunction(text, elem) {
        alert("edit" + text + " : " + elem);
    }
})();
