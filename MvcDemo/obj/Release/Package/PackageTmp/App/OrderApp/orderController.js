MainApp.controller('OrderCtrl', function ($scope, $location, $route, OrderService) {
    $scope.IsLoad = true;
    $scope.totalRecords = 0;
    $scope.currentPage = 1;
    $scope.pageSize = 10;


    $scope.pageChanged = function () {
        $scope.IsLoad = true;
        GetData();
    }

    $scope.Detail = function (id) {
        $location.path('Order/Detail/'+id);
    }

    var GetData = function () {
        OrderService.getData($scope.currentPage, $scope.pageSize).then(function (response) {
            $scope.IsLoad = false;
            $scope.totalRecords = response.Total;
            $scope.Orders = response.Data;
        }, function () {
            $scope.IsLoad = false;
            $scope.error = '取得資料錯誤';
        })
    }

    GetData();
});