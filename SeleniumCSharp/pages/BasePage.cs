using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharp.pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        // Constructor
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            // Java: Duration.ofSeconds(10) -> C#: TimeSpan.FromSeconds(10)
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // --- Explicit Waits ---

        protected IWebElement WaitForElementVisible(By locator)
        {
            // Java: visibilityOfElementLocated -> C#: ElementIsVisible
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected IWebElement WaitForElementToBeClickable(By locator)
        {
            // C# usa Mayúscula inicial
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        // --- Common Actions ---

        protected void Click(By locator)
        {
            WaitForElementVisible(locator);
            WaitForElementToBeClickable(locator).Click();
        }

        protected void Type(By locator, string text)
        {
            IWebElement element = WaitForElementVisible(locator);
            element.Clear(); // Mayúscula
            element.SendKeys(text); // Mayúscula
        }

        protected string GetText(By locator)
        {
            // .getText() en Java pasa a ser la propiedad .Text en C#
            return WaitForElementVisible(locator).Text;
        }

        protected string GetCurrentUrl()
        {
            // .getCurrentUrl() en Java pasa a ser la propiedad .Url en C#
            return driver.Url;
        }

        protected bool IsElementDisplayed(By locator)
        {
            try
            {
                // .isDisplayed() en Java pasa a ser la propiedad .Displayed en C#
                return WaitForElementVisible(locator).Displayed;
            }
            catch (WebDriverTimeoutException) // En C#, el wait lanza WebDriverTimeoutException
            {
                return false;
            }
        }
    }
}
