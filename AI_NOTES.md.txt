# AI_NOTES.md

## AI Tools Used

I used GitHub Copilot in Visual Studio during development for code suggestions, implementation guidance, and reviewing different approaches.

I did not use the AI output as-is. I reviewed the suggestions against the exercise requirements and adjusted them when needed.

## Prompts

A few prompts that were useful:

- "Suggest a simple structure for the weather API without over-engineering it."
- "How to handle different date formats and invalid dates like without throwing an exception?"
- "Review the implementation for invalid dates, API failures, and duplicate API calls."

## AI Suggestions I Changed

One suggestion was to introduce additional architectural layers. For this exercise, I felt that would add unnecessary complexity, so I kept the backend flow simple:

`Controller -> WeatherService -> OpenMeteoHttpClient`

I also kept date parsing and JSON file storage as small helper classes to keep the responsibilities clear.

## What I Did Manually

I reviewed the requirements and made the final decisions about the structure and implementation.

I manually:

- Tested the supported date formats and invalid date handling.
- Verified the Open-Meteo API response and error handling.
- Tested local JSON storage and confirmed cached data was reused.
- Verified the backend API before connecting the Angular UI.
- Tested the Angular loading, error, table display, and sorting behavior.
- Reviewed the final code and kept the implementation focused on the exercise requirements.