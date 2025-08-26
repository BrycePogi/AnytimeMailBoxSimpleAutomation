using NUnit.Framework;
using OpenQA.Selenium;
using AnytimeMailboxTests.Drivers;
using AnytimeMailboxTests.Pages;

namespace AnytimeMailboxTests.Tests
{
    public class SearchTests
    {
        private IWebDriver driver;
        private HomePage homePage;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.CreateDriver();
            homePage = new HomePage(driver);
            homePage.GoTo();
        }

        [Test]
        public void AddressSearch_ShouldReturnLocation()
        {
            homePage.Search("New York");
            Assert.That(driver.PageSource.Contains("New York"), Is.True, "Expected location not found in results.");
        }

        [Test]
        public void AddressSearch_NoResultsFound()
        {
            homePage.Search("SamplePlacesEctctctctct");
            Assert.That(driver.PageSource.Contains("We are unable to locate the place you entered. Please try again.") ||
                        driver.PageSource.Contains("We couldn’t find"),
                        Is.True, "Expected error message not shown.");
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
