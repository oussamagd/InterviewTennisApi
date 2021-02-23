# TennisApi

## Description
A net core api with the following routes

GET /api/players			Get all players ordered by Id. </br>
GET /api/players/{id}		Get a player by Id or 404 if player doesn't exist. </br>
DELETE /api/players/{id}	Delete a player by Id and return 204 or 404 if player doesn't exist.  </br>
GET /index.html				Contains Api Swagger documentation. </br>

## How to run 
1/This application use .net core 2.2 so we have to have this version or above installed </br>
2/Clone the TennisApi Repo https://github.com/oussamagd/InterviewTennisApi.git </br>
3/Open TennisApi.sln file then click on F5 to run the project </br>
Or open TennisApi folder and run the command : dotnet run </br>


## How to run unit test
To run the unit test we can </br>
From visual studio open test explorer and click run all </br>
Or open TennisApiTest folder and run the command : dotnet test </br>

## How to test the routes
For Get request we can use any browser or tools like postman </br>
For delete request we can use tools like postman </br>
