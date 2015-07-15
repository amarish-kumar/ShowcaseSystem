(function() {
    'use strict';

    angular
        .module('showcaseSystem')
        .factory('httpResponseInterceptor', ['$q', 'notifier', function ($q, notifier) {
            return {
                'response': function (response) {
                    if (response.data.success !== undefined) {
                        if (response.data.success === true) {
                            response.data = response.data.data;
                        }
                        else if (response.data.success === false) {
                            notifier.error(response.data.errorMessage);
                            return $q.reject(response.data.errorMessage);
                        }
                    }
                    return response;
                },
                'responseError': function (rejection) {
                    notifier.error('No connection to the server! Your Internet may be down!');
                    return $q.reject(rejection);
                }
            };
        }]);
}());