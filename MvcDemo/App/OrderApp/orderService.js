MainApp.factory('OrderService', function ($http, $q) {
    return {
        getData: function (currentPage, pageSize) {
            var deferred = $q.defer();
            $http.get('/api/Orders', { params: { CurrentPage: currentPage, PageSize: pageSize } })
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        },
        getDetail: function (deliveryID) {
            var deferred = $q.defer();
            $http.get('/api/Orders', { params: { DeliveryID: deliveryID } })
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        }
    }
});