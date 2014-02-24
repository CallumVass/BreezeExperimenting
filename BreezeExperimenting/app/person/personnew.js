(function () {
    'use strict';
    var controllerId = 'personnew';
    angular.module('app').controller(controllerId, ['$location', 'common', 'datacontext', personnew]);

    function personnew($location, common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'New Person';
        vm.person = undefined;
        vm.createPerson = createPerson;

        activate();

        function activate() {
            common.activateController([getNewPerson()], controllerId)
                .then(function () { log('Activated New Person View'); });
        }

        function getNewPerson() {
            return datacontext.createEntity('Person').then(function(data) {
                vm.person = data;

                return data;
            });
        }

        function goToDashboard() {
            $location.path('/');
        }

        function createPerson() {
            datacontext.save().then(function (saveResult) {
                goToDashboard();
            }, function (error) {
                vm.isSaving = false;
            });
        }
    }
})();