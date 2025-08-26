using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AnytimeMailboxTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        // Locators
        private IWebElement HomePageLoginButton => driver.FindElement(By.XPath("//ul[@id='menu-homepage-1']//li[contains(@class, 'loginmenu loginlink')]"));
        private IWebElement EmailInput => driver.FindElement(By.Id("f_uid"));
        private IWebElement PasswordInput => driver.FindElement(By.Id("f_pwd"));
        private IWebElement LoginButton => driver.FindElement(By.XPath("//button[contains(@class,'btn-login-100') and normalize-space()='Log In']"));
        
        private By RecaptchaIframe => By.CssSelector("iframe[title='reCAPTCHA']");
        private By RecaptchaCheckbox => By.CssSelector("div.recaptcha-checkbox-border");
        private By ErrorMessage => By.XPath("//div[contains(@class,'alert-danger')]");

        public void GoTo() => driver.Navigate().GoToUrl("https://www.anytimemailbox.com/");

        private void WaitUntilElementIsDisplayed(By locator, int timeoutInSeconds = 10)
        {
            var localWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            localWait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement GetRecaptchaCheckBoxEle()
        {
            // Switch into iframe first
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(RecaptchaIframe));

            // Wait until the checkbox inside the iframe is clickable
            var checkbox = wait.Until(ExpectedConditions.ElementToBeClickable(RecaptchaCheckbox));

            return checkbox;
        }

        public void Login(string email, string password)
        {
            HomePageLoginButton.Click();
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);

            // Click reCAPTCHA (inside iframe)
            GetRecaptchaCheckBoxEle().Click();
            Console.WriteLine("reCAPTCHA clicked.");

            // Switch back to main content after handling iframe
            driver.SwitchTo().DefaultContent();

            // Try login
            LoginButton.Click();
        }

        public string GetErrorMessage()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(ErrorMessage)).Text;
        }
    }
}
