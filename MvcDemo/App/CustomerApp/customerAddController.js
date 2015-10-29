MainApp.controller('CustAddCtrl', function ($scope, $location, $route, CustService) {
    $scope.CustomerID = '';
    $scope.AttribName = '';
    $scope.CompanyName = '';
    $scope.EarNo = '';
    $scope.JoinMan = '';
    $scope.Tel1 = '';
    $scope.Tel2 = '';
    $scope.Fax = '';
    $scope.MobilePhone = '';
    $scope.CompanyAddress = '';
    $scope.DeliveryAddress = '';

    $scope.Add = function () {
        var Customer = {
            CustomerID: $scope.CustomerID,
            AttribName: $scope.AttribName,
            CompanyName: $scope.CompanyName,
            EarNo: $scope.EarNo,
            JoinMan: $scope.JoinMan,
            Tel1: $scope.Tel1,
            Tel2: $scope.Tel2,
            Fax: $scope.Fax,
            MobilePhone: $scope.MobilePhone,
            CompanyAddress: $scope.CompanyAddress,
            DeliveryAddress:$scope.DeliveryAddress
        }

        CustService.AddCustomer(Customer).then(function (response) {
            alert('新增成功');
            $scope.IsLoad = false;
        }, function () {
            $scope.error = '新增失敗';
            $scope.IsLoad = false;
        })
    }
});