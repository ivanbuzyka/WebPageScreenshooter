# WebPageScrenshooter
Simple console app that can be used to produce screenshots of the web page.
The app can be scheduled to run in any scheduler.
The app is using beautiful [Playwright](https://playwright.dev/) project.

## Getting started
1. Restore Nuget packages, build project
2. Make sure Node JS is installed on your machine
3. Run ```npx playwright install``` in the folder with executable produced by build
4. Run exe wth parameters (or schedule it to run). Example:
    ```WebPageScreenshooter.exe https://www.forex.com/ie/trading-academy/courses/how-to-trade/buying-and-selling/ 60000```
    **Note:** second parameter is a timeout for page request in milliseconds