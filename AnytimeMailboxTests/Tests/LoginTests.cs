using NUnit.Framework;
using OpenQA.Selenium;
using AnytimeMailboxTests.Drivers;
using AnytimeMailboxTests.Pages;

namespace AnytimeMailboxTests.Tests
{
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.CreateDriver();
            loginPage = new LoginPage(driver);
            loginPage.GoTo();
        }

        [Test]
        public void InvalidLogin_ShouldShowError()
        {
            loginPage.Login("wronguser@test.com", "WrongPassword");
            string error = loginPage.GetErrorMessage();
            Assert.That(error.Contains("Invalid credentials, please try again.") || error.Contains("incorrect"),
                        Is.True, "Expected error message not displayed.");
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
