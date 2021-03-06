﻿
/// <reference path="C:\Users\User\Documents\Visual Studio 2017\Projects\SignUp\SignUp\Scripts\angular.js"/>

var myApp = angular.module("myApp", ['ngRoute', 'agentService']);

myApp.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            

            when('/Home', {
                templateUrl: 'View/Home.html',
                controller: 'HomeController'
            }).
            when('/SignUp', {
                templateUrl: 'View/SignUp.html',
                controller: 'SignUpController'
            }).
            when('/LogIn', {
                templateUrl: 'View/LogIn.html',
                controller: 'LogInController'
            }).

            when('/Profile',
            {
                templateUrl: 'View/Profile.html',
                controller: 'UpdateProfileController'
            }).

            when('/Property',
            {
                templateUrl: 'View/Property.html',
                controller: 'PropertyController'
            }).
            when('/Upload',
            {
               templateUrl: 'View/UploadImage.html',
               controller: 'ImageController'
            }).

            otherwise({ redirectTo: '/Home' });

    }

]);
myApp.directive('ngFiles', ['$parse', function ($parse) {
    function fn_link(scope, element, attrs) {
        var onChange = $parse(attrs.ngFiles);
        element.on('change', function (event)
        {
            onChange(scope, { $files: event.target.files });
        })
    }

    return {
        link: fn_link
    }


}])
//filtering section of the properties based on the user request
myApp.controller("HomeController", function ($rootScope,$location,$scope, AgentApi) {
  
    getAlltbProperties();
    function getAlltbProperties() {
        AgentApi.getProperties().then(function (response) {
            $scope.tbProperties = response.data;
        }),
            function (response) {
            alert("error in adding");
        };
    }                 
});
//SignUp controller is used to register new user and passing user information 
myApp.controller("SignUpController", function ($location,$scope, AgentApi) {
    $scope.addtbAgents = function () {
        var agentToAdd =
            {
                'Email': $scope.Email,

                'Password': $scope.Password
            };
        AgentApi.addAgents(agentToAdd)
            .then
            (function (response) {
                alert("Agent added");
                $location.path('/Home');
               
              

            }),
            function (response) {
                alert("error in adding");
            }
            ;
    };
    
   
   
});

myApp.controller("LogInController", function ($location, $rootScope, $scope, AgentApi) {

    $scope.gettbAgents = function () {

        AgentApi.getAgents($scope.Username, $scope.Password)
            .then
            (function (response) {
                if (response.data === null) {
                    alert("error");


                }
                else {
                   
                    alert("Successfully Logged In " + response.data.Email);

                    $rootScope.userData = response.data;
                  //  $localStorage = $rootScope.userData;
                    alert(JSON.stringify($rootScope.userData));

                    $rootScope.profile = response.data.Email;
                    $location.path('/Home');



                    //$scope.Username = undefined;
                    //$scope.Password = undefined;
                    // $rootscope.UserInfo = response.data;
                    //  $rootscope.Profile = response.data.Email;
                    // window.location.href = "index.html";


                }


            }),
            function (response) {
                alert("error in Logging in");
            };


    };
   
});

//Log Out Controller will be used to empty the root Variable and send you to the main page and still in process

myApp.controller("LogOutController", function ($rootScope,$location,$scope) {
    $scope.logout() = function () {
        $rootScope.userData=false,
            $location.path({ redirectTo: '/Home' });
    };

});


// update Agent Details Section
myApp.controller("UpdateProfileController", function ($location, $rootScope, $scope, AgentApi)
{
    $scope.FirstName = $rootScope.userData.FirstName;
    $scope.LastName = $rootScope.userData.LastName;
    $scope.Email = $rootScope.userData.Email;
    $scope.Password = $rootScope.userData.Password;
    $scope.MobileNum = $rootScope.userData.MobileNum;
    $scope.Agent_ID = $rootScope.userData.Agent_ID;
    $scope.Role = $rootScope.userData.Role;

    $scope.UpdateAgent = function () {
        var agentUpdate =
            {
                'Agent_ID': $scope.Agent_ID,
                'Email': $scope.Email,
                'Password': $scope.Password,
                'FirstName': $scope.FirstName,
                'LastName': $scope.LastName,
                'MobileNum': $scope.MobileNum,
                'Role':$scope.Role
            };


        AgentApi.EditAgent(agentUpdate)
            .then(function (response) {
                alert('You have updated your profile ' + agentUpdate.FirstName);
                $rootScope.userData= agentUpdate;
                $rootScope.profile = agentUpdate.Email;
                $localStorage = agentUpdate;
                $location.path('/Home');
            }),
            function (response)
            { alert('Not Updated'); };
    };
});


//Manage Property Section

myApp.controller("PropertyController", function ($rootScope, $location, $scope, AgentApi) {
  //  $scope.Agent_ID = $localStorage.userData.Agent_ID;
    $scope.Agent_ID = $rootScope.userData.Agent_ID;

     $scope.addTbProperty = function (){

        var propToAdd = {

            'Description': $scope.Description,
            'NumOfBed': $scope.NumOfBed,
            'NumOfBath': $scope.NumOfBath,
            'NumOfGarage': $scope.NumOfGarage,
            'FloorSize': $scope.FloorSize,
            'Price': $scope.Price,
            'PropertySize': $scope.PropertySize,
            'Category' : $scope.Category,
            'Monthly_Levy' :$scope.Monthly_Levy,
            'Monthly_Rate' : $scope.Monthly_Rate,
            'PriceTerm' : $scope.PriceTerm,
            'OccupationDate' : $scope.OccupationDate,
            'Agent_ID' : $scope.Agent_ID,
            'Street' : $scope.Street,
            'City' : $scope.City
        };
        AgentApi.addProperty(propToAdd).
            then
            (function (response) {
                AgentApi.getProp($scope.Description, $scope.NumOfBed, $scope.NumOfBath, $scope.NumOfGarage, $scope.FloorSize,
                    $scope.Price, $scope.PropertySize, $scope.Category, $scope.Monthly_Levy, $scope.Monthly_Rate,
                    $scope.PriceTerm, $scope.OccupationDate, $scope.Agent_ID, $scope.Street, $scope.City).
                    then(function (response) {
                        $rootScope.userData = userData + response.data
                    }
                    );
                
                
                
                alert("New Property Added by " + $rootScope.userData.FirstName);
              // $localStorage= $localStorage
               // $rootScope.userData = $rootScope.userData + response.data;
             //   alert($rootScope.userData);
                $location.path('/Upload');
                

            }),
            function (response) {
                alert("error in adding property");
            };

    };

});

myApp.controller("ImageController", function ($rootScope, $location, $scope, AgentApi) {
    $scope.Prop_ID = $rootScope.userData.Prop_ID;
   
    var formdata = new FormData();

    //get images for viewing
    $scope.getTheFiles = function ($files) {
        $scope.imagesrc = [];

        for (var i = 0; i < $files.length; i++) {
            var reader = new FileReader();

            reader.fileName = $files[i].name;
            reader.onload = function (event) {
                var image = {};
                image.Name = event.target.fileName;
                image.Size = (event.total / 1024).toFixed(2);
                image.Src = event.target.result;
                $scope.imagesrc.push(image);
                $scope.$apply();

            }

            reader.readAsDataURL($files[i]);
        }
        angular.forEach($files, function (value, key) {

            formdata.append(key, value);

        })
    } 

    $scope.uploadFiles = function () {

        var myDataQuery = "?Prop_ID=" + $scope.Prop_ID;
        

        //call service function
        AgentApi.UploadImages(formdata).then(function (d) {
            alert(d.data);
            $scope.reset();
            $location.path("/Home");

        }), function () {
            alert("Failed");
            $scope.reset();
        };

    }
               
              

});



