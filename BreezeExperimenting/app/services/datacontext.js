(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', 'entityManagerFactory', datacontext]);

    function datacontext(common, emFactory) {
        var $q = common.$q;
        var manager = emFactory.newManager();
        var logError = common.logger.getLogFn(this.serviceId, 'error');
        var EntityQuery = breeze.EntityQuery;

        var service = {
            getPeople: getPeople,
            getMessageCount: getMessageCount
        };

        return service;

        function getMessageCount() { return $q.when(72); }

        function getPeople() {
            return EntityQuery  .from('People')
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
    }
})();