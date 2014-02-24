(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['config', 'common', 'entityManagerFactory', datacontext]);

    function datacontext(config, common, emFactory) {
        var $q = common.$q;
        var manager = emFactory.newManager();
        var logSuccess = common.logger.getLogFn(this.serviceId, 'success');
        var logError = common.logger.getLogFn(this.serviceId, 'error');
        var EntityQuery = breeze.EntityQuery;

        var service = {
            getPeople: getPeople,
            getMessageCount: getMessageCount,
            createEntity: createEntity,
            save: save
        };

        return service;

        function getMessageCount() { return $q.when(72); }

        function createEntity(entityName) {
            if (manager.metadataStore.isEmpty()) {
                return manager.fetchMetadata().then(function () {
                    return manager.createEntity(entityName);
                });
            } else {
                return $q.when(manager.createEntity(entityName));
            }
        }

        function getPeople() {
            return EntityQuery.from('People')
                                .toType('Person')
                                .using(manager)
                                .execute()
                                .then(querySucceeded, _queryFailed);

            function querySucceeded(data) {
                var people = data.results;

                return people;
            }
        }

        function _queryFailed(error) {
            var msg = config.appErrorPrefix + 'Error retrieving data.' + error.message;
            logError(msg, error);
            throw error;
        }

        function save() {
            return manager.saveChanges()
                .to$q(saveSucceeded, saveFailed);

            function saveSucceeded(result) {
                logSuccess('Saved data', result, true);
            }

            function saveFailed(error) {
                var msg = config.appErrorPrefix + 'Save failed: ' +
                    breeze.saveErrorMessageService.getErrorMessage(error);
                error.message = msg;
                logError(msg, error);
                throw error;
            }
        }
    }
})();