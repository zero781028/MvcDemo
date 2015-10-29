MainApp.factory('CustService', function ($http, $q) {
    return {
        getData: function (currentPage, pageSize) {
            var deferred = $q.defer();
            $http.get('/api/Customers', { params: { CurrentPage: currentPage, PageSize: pageSize } })
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        },
        getCustomer: function (customerID) {
            var deferred = $q.defer();
            $http.get('/api/Customers', { params: { CustomerID:customerID } })
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        },
        AddCustomer: function (customer) {
            var deferred = $q.defer();
            $http.post('/api/Customers', customer)
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        },
        UpdateCustomer: function (customer) {
            var deferred = $q.defer();
            $http.put('/api/Customers', customer)
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        },
        DeleteCustomer: function (Cust) {
            var deferred = $q.defer();
            $http.delete('/api/Customers?id='+Cust.CustomerID)
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        }
    }
});