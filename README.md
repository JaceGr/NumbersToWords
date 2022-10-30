# NumbersToWords
This is a simple web app that converts a dollar amount into words. It is built with both react and dotnet to demonstrate how to build a full stack application.

## Application Overview
This application is built using the dotnet 6 web application with react structure. The dotnet project can be found in the NumToWords directory with the front end source code nested in the NumToWords/ClientApp directory.  
The NumToWordsTesting directory contains an xUnit test project.

The maximum value was chosen as 10 trillion as precision issues were introduced at higher numbers.

## Running Application Instructions
To run the application, navigate to the dotnet project in NumToWords directory and run: `dotnet run`.
This will start the dotnet server. To access the web application, go to https://localhost:7184 or http://localhost:5267. This will start the react development server and route the browser to port 44487 where the front end application can be accessed. This is set up with the dotnet SPA proxy routing all requests through to the server in the development configuration. 

## Test plan
A suite of unit tests for the server side conversion and validation functionality are provided in `/NumToWordsTesting`
