using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumCSharp;

[TestClass]
public class CheckoutTests
{
    private IWebDriver driver;

    [TestInitialize] // Equivalente a @BeforeMethod
    public void SetUp()
    {
        ChromeOptions options = new ChromeOptions();

        // Preferencias (HashMap en Java -> AddUserProfilePreference en C#)
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    [TestMethod]
    public void CheckoutNoData()
    {
        // Step 1: Login
        driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        driver.FindElement(By.Id("login-button")).Click();

        // Step 2: Agregar producto
        driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();

        // Step 3: Click carrito
        driver.FindElement(By.ClassName("shopping_cart_link")).Click();

        // Step 4: Click checkout
        driver.FindElement(By.Id("checkout")).Click();

        // Step 5: Click Continue
        driver.FindElement(By.Id("continue")).Click();

        // --- EXPLICIT WAIT (WebDriverWait) ---
        // Java: new WebDriverWait(driver, Duration.ofSeconds(20))
        // C#:   new WebDriverWait(driver, TimeSpan.FromSeconds(20))
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        IWebElement errorText = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@data-test = 'error']")));

        string errorStringName = errorText.Text;

        Assert.AreEqual("Error: First Name is required", errorStringName);
    }

    [TestMethod]
    public void E2E()
    {
        // Step 1: Login
        driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        driver.FindElement(By.Id("login-button")).Click();

        // Step 2: Add to cart
        driver.FindElement(By.XPath("//*[@data-test = 'add-to-cart-sauce-labs-backpack']")).Click();

        // Step 3: Shopping Cart
        driver.FindElement(By.XPath("//*[@data-test = 'shopping-cart-link']")).Click();

        // Step 4: Checkout
        driver.FindElement(By.Id("checkout")).Click();

        // Step 5: Formulario
        driver.FindElement(By.Id("first-name")).SendKeys("Adrian");
        driver.FindElement(By.Id("last-name")).SendKeys("Flores");
        driver.FindElement(By.Id("postal-code")).SendKeys("90210");
        driver.FindElement(By.Id("continue")).Click();

        // Step 6: Finish
        driver.FindElement(By.XPath("//*[contains(text(),'Finish')]")).Click();

        // --- FLUENT WAIT ---
        // En C#, FluentWait se implementa usando la clase 'DefaultWait<T>'

        DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);

        // Configuración del Wait
        fluentWait.Timeout = TimeSpan.FromSeconds(30);          // Tiempo máximo
        fluentWait.PollingInterval = TimeSpan.FromSeconds(5);   // Frecuencia de revisión
        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); // Excepciones a ignorar

        // Ejecución del Wait
        IWebElement element = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("complete-header")));

        Assert.AreEqual("Thank you for your order!", element.Text);
    }

    [TestCleanup] // Equivalente a @AfterMethod
    public void TearDown()
    {
        if (driver != null)
        {
            driver.Quit();
        }
    }
}
