# Historical Weather Application

A full-stack web application built using .NET 10 and Angular 22 to retrieve and display historical weather data for Dallas.

The backend reads dates from a text file, validates and normalizes the dates, retrieves historical weather data from the Open-Meteo API, and stores successful responses locally. The Angular UI displays the weather results and any errors for invalid or unavailable dates.

## Technologies Used

- .NET 10
- ASP.NET Core Web API
- C#
- Angular 22
- TypeScript
- Open-Meteo Historical Weather API

## Prerequisites

Make sure the following are installed:

- .NET 10 SDK
- Node.js
- npm

## Running the Application

### Backend

Navigate to the backend project:

cd Backend/WeatherApi/WeatherApi


Run the API:

dotnet run

The API will be available at:

https://localhost:7097/api/weather

### Frontend

Open another terminal and navigate to the Angular project:

cd Frontend/weather-ui

Install the dependencies:

npm install

Start the Angular application:

npm start

Open the application in the browser:

http://localhost:4200

## Assumptions

- Historical weather data is retrieved for Dallas using latitude `32.78` and longitude `-96.8`.
- Input dates can be provided in the supported formats and valid dates are normalized to `yyyy-MM-dd`.
- Invalid dates are handled gracefully and returned with an error message.
- Successful weather responses are stored locally in the `weather-data` folder and reused to avoid repeated API calls.
- Network/API failures and unavailable weather data are handled for each date without stopping the entire request.
- The Angular application uses a local proxy configuration to communicate with the backend during development.