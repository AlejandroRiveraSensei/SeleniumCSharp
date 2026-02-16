using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCSharp;

[TestClass]
public class LoginTests
{
    private IWebDriver driver;

    // Se ejecuta antes de CADA [TestMethod]
    [TestInitialize]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        driver.Manage().Window.Maximize();
    }

    // Se ejecuta después de CADA [TestMethod]
    [TestCleanup]
    public void TearDown()
    {
        if (driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }
    }

    [TestMethod] // Indica que este método es una prueba ejecutable
    public void LoginBlocked()
    {
        driver.FindElement(By.Id("user-name")).SendKeys("locked_out_user");
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        driver.FindElement(By.Id("login-button")).Click();

        string errorMsj = driver.FindElement(By.XPath("//*[@data-test = 'error']")).Text;
        Console.WriteLine("El mensaje de error es: " + errorMsj);

        Assert.AreEqual("Epic sadface: Sorry, this user has been locked out.", errorMsj);
    }

    [TestMethod]
    public void LoginSuccess()
    {
        driver.FindElement(By.Name("user-name")).SendKeys("standard_user");
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        driver.FindElement(By.Id("login-button")).Click();

        string productText = driver.FindElement(By.ClassName("title")).Text;

        bool isEqual = productText.Contains("Products");
        Assert.IsTrue(isEqual);
    }

    [TestMethod]
    public void LoginInvalidUser()
    {
        driver.FindElement(By.Id("user-name")).SendKeys("incorrect_user");
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        driver.FindElement(By.Name("login-button")).Click();

        IWebElement lblError = driver.FindElement(By.XPath("//*[@data-test = 'error']"));

        Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", lblError.Text);
    }

    [TestMethod]
    public void LoginEmptyPassword()
    {
        driver.FindElement(By.XPath("//*[@class = 'submit-button btn_action']")).Click();

        string error = driver.FindElement(By.XPath("//*[@data-test= 'error']")).Text;

        // Assert.IsFalse funciona igual en MSTest
        Assert.IsFalse(error.Contains("Password is not required"));
    }

    [TestMethod]
    public void LogoutTest()
    {
        // Nota: En MSTest, como [TestInitialize] ya abrió un navegador, 
        // aquí lo cerramos para abrir uno nuevo con opciones específicas.
        driver.Quit();

        ChromeOptions options = new ChromeOptions();
        // Desactivar gestor de contraseñas y detecciones
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);

        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");

        // Step 1: Login
        driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        driver.FindElement(By.Id("login-button")).Click();

        // Step 2: Click en boton de Menu
        driver.FindElement(By.Id("react-burger-menu-btn")).Click();

        Thread.Sleep(1000);

        // Step 3: Click en logout
        driver.FindElement(By.Id("logout_sidebar_link")).Click();

        // Validar URL
        Assert.AreEqual("https://www.saucedemo.com/", driver.Url);

        // Validar Input User
        Assert.IsTrue(driver.FindElement(By.Id("user-name")).Displayed);
    }
}
