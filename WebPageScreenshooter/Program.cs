using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace WebPageScreenshooter
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            string hostName = args[0];
            float timeout = 30000;
            float.TryParse(args[1], out timeout);

            Console.WriteLine($"Page request timeout: {timeout}");
            Console.WriteLine($"Going to take a screenshot from {hostName}");

            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = true });
            var context = await browser.NewContextAsync();
            context.SetDefaultTimeout(timeout);
            var page = await context.NewPageAsync();
            await page.GotoAsync(hostName);
            var screenshotName = $"{ DateTime.UtcNow.ToString("yyyy-MM-dd_HH.mm.ss") }.png";
            var filePath = Path.GetFullPath($"./screenshots/{screenshotName}");
            await page.ScreenshotAsync(new() { FullPage = true, Path = filePath });

            await context.CloseAsync();
        }
    }
}
