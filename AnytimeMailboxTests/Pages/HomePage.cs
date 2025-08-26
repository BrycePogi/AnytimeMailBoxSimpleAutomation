using OpenQA.Selenium;

namespace AnytimeMailboxTests.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        public HomePage(IWebDriver driver) => this.driver = driver;

        // Locators
        private IWebElement SearchBox => driver.FindElement(By.XPath("//input[@id = 'lookup']"));
        private IWebElement SearchButton => driver.FindElement(By.XPath("//button[@type = 'submit']"));

        public void GoTo() => driver.Navigate().GoToUrl("https://www.anytimemailbox.com/");

        public void Search(string keyword)
        {
            SearchBox.Clear();
            SearchBox.SendKeys(keyword);
            SearchButton.Click();
        }

       /* public WebElement getLocationResultsContainer()
        {
            
        }*/
    }
}
