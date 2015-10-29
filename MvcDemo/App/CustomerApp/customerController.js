MainApp.controller('CustCtrl', function ($scope, $location, $route, CustService) {
    $scope.IsLoad = true;
    $scope.totalRecords = 0;
    $scope.pageSize = 5;
    $scope.currentPage = 1;

    $scope.pageChanged = function () {
        $scope.IsLoad = true;
        GetData();
    }

    $scope.Update = function (id) {
        $location.path('/Customer/Edit/'+id);
    }

    $scope.Delete = function (Cust) {
        var sureDelete = confirm('確定要刪除此資料嗎?');
        if (sureDelete) {
            CustService.DeleteCustomer(Cust).then(function () {
                alert('刪除成功');
                $scope.currentPage = 1;
                GetData();
                $scope.IsLoad = false;
            },
            function () {
                alert('刪除失敗');
                $scope.IsLoad = false;
            })
        }
    }

    var GetData = function () {
        CustService.getData($scope.currentPage, $scope.pageSize).then(function (response) {
            $scope.Customers = response.Data;
            $scope.totalRecords = response.Total;
            $scope.IsLoad = false;
        }, function () {
            $scope.error = '取得資料錯誤';
            $scope.IsLoad = false;
        })
    }

    GetData();
});