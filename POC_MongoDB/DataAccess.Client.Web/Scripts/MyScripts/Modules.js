var app = angular.module("ApplicationModule", []);

app.factory("ShareData", function () {
    return { value: 0 }
});

//Showing Routing  
//app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
//    debugger;
//    //$routeProvider.when('/Get',
//    //                    {
//    //                        templateUrl: 'ManageStudentInfo/ShowAllStudents',
//    //                        controller: 'ShowArtistsController'
//    //                    });
//    //$routeProvider.otherwise(
//    //                    {
//    //                        redirectTo: '/'
//    //                    });

//    //$locationProvider.html5Mode(true).hashPrefix('!')
//}]);