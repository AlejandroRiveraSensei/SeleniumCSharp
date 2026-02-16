using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCSharp
{
    [TestClass]
    public class UsingSeleniumTest
    {
        [TestMethod]
        public void UrlCheckTest()
        {

            // Initiate Webdriver
            IWebDriver driver = new ChromeDriver();

            // adding an implicit wait of 20 secs
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            // launch the application
            driver.Navigate().GoToUrl("https://www.google.com");

            // get the page title
            String pageTitle = driver.Title;
            System.Diagnostics.Debug.WriteLine("Page title is: " + pageTitle);
        }
    }
}
