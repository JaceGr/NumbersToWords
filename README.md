# NumbersToWords
This is a simple web app that converts a dollar amount into words. 

## Application Overview
This application is built using the dotnet 6 web application with react structure. The dotnet project can be found in the NumToWords directory with the front end source code nested in the NumToWords/ClientApp directory.  
The NumToWordsTesting directory contains an xUnit test project.

There is one endpoint that is used as the entry-point for a clientside request which can be found in `NumToWords/Controllers/ConversionController.cs`. This controller creates an instance of the ConversionService class and utilises its methods to validate input and convert the number to words before returning the result.

## Running Application Instructions
To run the application, navigate to the dotnet project in NumToWords directory and run: `dotnet run`.
This will start the dotnet server. To access the web application, go to https://localhost:7184 or http://localhost:5267. This will start the react development server and route the browser to port 44487 where the front end application can be accessed. This is set up with the dotnet SPA proxy routing all requests through to the server in the development configuration.  


## Solution Explanation
The functionality in the ConversionService that was utilised for the conversion was based around the idea of building reusable functions that could break down the problem into smaller more understandable chunks of conversion. 
The reuse of `ConvertSection()` removed a large amount of code that would be repetitive as for each three digit numbers, the hundreds, tens and units have to be converted to words.
A recursive solution was considered but for code readability the chosen solution was desired. 

The application structure of separating the logic from the controller into a separate C# class was to improve readability and scalability in the case that this application was to be extended.

The maximum value was chosen as 10 trillion as precision issues were introduced at higher numbers.

## Test plan
A suite of unit tests for the server side conversion and validation functionality are provided in `/NumToWordsTesting`. This test suite is broken up into three files.
These three files test the validation of inputs, the internal functionality of reused functions for converting three digit segments into their written form and finally a holistic suite testing the full conversion.
Edge cases in terms of the allowed range of numbers and characters were tested throughout to ensure that this solution was robust.

With further work, I would next implement API test and some Jest tests for the front end to improve test coverage over the entire application. The current unit tests however, do ensure functionality over the conversion.
