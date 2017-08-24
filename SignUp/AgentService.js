///<reference path="c: \users\user\documents\visual studio 2017\Projects\Prop24_Registration\Prop24_Registration\Scripts\angular.js"/>

var agentService = angular.module('agentService', []);

agentService.factory('AgentApi', function ($http,$q)

{
    var urlAgent = "http://localhost:4250/api";
    var AgentApi = {};

    //Login using Agent Credential

    AgentApi.getAgents = function (Username, Password) {
        return $http.get(urlAgent + "/tbAgents"+"?Username=" + Username + "&Password=" + Password);
    };

    //Registration of Agent 

    AgentApi.addAgents = function (agentToAdd) {
        return $http.post(urlAgent + '/tbAgents/', agentToAdd);
    };


//Update of Agent Profile Information (Update Agent Information)
    AgentApi.EditAgent = function (agentUpdate)
    {
         var request= $http({
           
            method: 'PUT',
            url: urlAgent + '/tbAgents/',
            data: agentUpdate

        }); 
       
         return request;
     
    };

    // Get All the properties in tbl property (Search Properties Section)

    AgentApi.getProperties = function () {
       return $http.get(urlAgent + '/GetAll');
    };

    // Get Method in order to retrieve the prop_ID
    AgentApi.getProp()= function(){
        return $http.get(urlAgent + "/tbProperties" + "?Description=" + Desc + "&NumOfBed=" + NoBed + "&NumOfBath" + NoBath + "&NumOfGarage" + NoGarage + "&FloorSize" + fSize + "&Price" + Price + "&PropertySize" + pSize + "&Category" + Cat + "&Monthly_Levy" + MonthLevy + "&Monthly_Rate" + MonthlyRate + "&PriceTerm" + PriceT + "&OccupationDate" + OccupDate + "&Agent_ID" + A_ID + "&Street" + Street + "&City" + City
        )
    };


    //Registration of a property

    AgentApi.addProperty = function (propToAdd) {
        
        return $http.post(urlAgent + '/tbProperties/', propToAdd);

    };


    //Upload Image in table Image

    
    AgentApi.UploadImages = function (formdata) {

        var request = {
            method: 'POST',
            url: urlAgent + '/Image',
            data: formdata,
            headers: {
                'Content-Type': undefined
            }
        };

        return $http(request);

    };
    return AgentApi;
});
 