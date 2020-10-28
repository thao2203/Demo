var app = angular.module("myapp", []);
console.clear();
app.controller("baiviet", function ($scope, $http) {

    $http({
        method: 'GET',
        url: '/BAIVIETs/get'
    }).then(function successCallback(response) {
        //$scope.getdcm(response.data["maDMC"]);
        console.clear();
        console.log(response.data);
        $scope.list = response.data;
    }, function errorCallback(response) {
        alert(response.data)
    })
}).filter("filterdate", function () {
    var re = /\/Date\(([0-9]*)\)\//;
    return function (x) {
        var m = x.match(re);
        if (m) return new Date(parseInt(m[1]));
        else return null;
    };
});;

//});
//app.controller("baiviet", function ($scope, $http) {
//    $scope.getdcm = function (madmc) {
//        $http({
//            method: 'GET',
//            url: '/BAIVIETs/getTenDMC?maDMC=' + madmc
//        }).then(function (json) {
//            $scope.listdmc = json.data;
//        });
//    }

//})