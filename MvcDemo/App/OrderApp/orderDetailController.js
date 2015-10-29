MainApp.controller('OrderDetailCtrl', function ($scope, $location, $routeParams, $route, OrderService) {
    var DeliveryID = $routeParams.id;
    $scope.IsLoad = true;

    $scope.go = function () {
        $location.path('Order');
    }

    OrderService.getDetail(DeliveryID).then(function (response) {
        $scope.OrderDetail = response.Data;
        $scope.DeliveryID = DeliveryID;
        $scope.totalRow = response.Total;
        $scope.IsLoad = false;
    }, function () {
        alert('取得資料錯誤');
        $scope.IsLoad = false;
    });
        
});