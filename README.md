# TennisApi

## Description
A net core api with the following routes

GET /api/players			Get all players ordered by Id
GET /api/players/{id}		Get a player by Id or 404 if player doesn't exist
DELETE /api/players/{id}	Delete a player by Id and return 204 or 404 if player doesn't exist 
GET /index.html				Contains Api Swagger documentation

## How to run 
1/This application use .net core 2.2 so we have to have this version or above installed
2/Clone the TennisApi Repo https://github.com/oussamagd/InterviewTennisApi.git
3/Open TennisApi.sln file then click on F5 to run the project
Or open TennisApi folder and run the command : dotnet run


## How to run unit test
To run the unit test we can 
From visual studio open test explorer and click run all
Or open TennisApiTest folder and run the command : dotnet test

## How to test the routes
For Get request we can use any browser or tools like postman
For delete request we can use tools like postman