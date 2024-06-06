# FGMHackerNewsAPI

FGMHackerNewsAPI is a ASP.NET Core web API that fetches and returns the best stories from the Hacker News API.

## Features

- Fetches top `n` stories from Hacker News
- Returns story details including title, URL, posted by, time, score, and comment count

## Getting Started
Prerequisites
.NET 6.0 SDK

#### Running the Application
Clone the repository:

 - gh repo clone FernandoMares/SantanderDeveloperCodingTest (Master Branch)
 - cd FGMHackerNewsAPI

Build and run the application:
 - dotnet build
 - dotnet run

The API will be available at http://localhost:7080/swagger/index.html or http://localhost:5092/swagger/index.html


## Project Structure
Controllers/
 - StoriesController.cs: Handles API requests and responses.

Models/
 - Story.cs: Defines the data structure for Story and StoryDto.

Services/
 - HackerNewsService.cs: Contains the logic for fetching data from the Hacker News API.

Program.cs: Configures and runs the ASP.NET Core application.
appsettings.json: Configuration settings for the application.

FGMHackerNewsAPI.csproj: Project file containing dependencies and target framework.

## Endpoints

GET /api/stories?count={count}

#### Response example

```json
[
  {
    "title": "A uBlock Origin update was rejected from the Chrome Web Store",
    "uri": "https://github.com/uBlockOrigin/uBlock-issues/issues/745",
    "postedBy": "ismaildonmez",
    "time": "2019-10-12T13:43:01+00:00",
    "score": 1716,
    "commentCount": 572
  },
  
]


