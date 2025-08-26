using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AnytimeMailboxTests.Drivers
{
    public class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }
    }
}
