using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCSharp;

[TestClass]
public class InventoryTests
{
    private IWebDriver driver;

    [TestInitialize] // Equivalente a @BeforeMethod
    public void SetUp()
    {
        ChromeOptions options = new ChromeOptions();

        // En Java usas un HashMap. En C# usamos AddUserProfilePreference directamente.
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    [TestMethod] // Equivalente a @Test
    public void AddProductTest()
    {
        // Step 1: Login
        driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        driver.FindElement(By.Id("login-button")).Click();

        // Step 2: Add Product
        driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();

        // Validar '1' en el carrito
        // .Text es Propiedad (sin paréntesis)
        string actualCount = driver.FindElement(By.ClassName("shopping_cart_badge")).Text;
        string expectedCount = "1";

        Assert.AreEqual(expectedCount, actualCount);
    }

    [TestMethod]
    public void RemoveProduct()
    {
        // Step 1: Login
        // DIFERENCIA: ImplicitWait en C# recibe un TimeSpan y se asigna con '='
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        driver.FindElement(By.Id("login-button")).Click();

        // Step 2: Click Add Product
        driver.FindElement(By.XPath("//*[@class = 'btn btn_primary btn_small btn_inventory ']")).Click();

        // Step 3: Click Remove
        driver.FindElement(By.Id("remove-sauce-labs-backpack")).Click();

        // --- Ejemplo FindElements (Listas) ---

        // Java: List<WebElement>
        // C#:   IList<IWebElement> (o simplemente 'var')
        IList<IWebElement> prodList = driver.FindElements(By.ClassName("inventory_item_name"));

        // Java: .size() -> C#: .Count
        Console.WriteLine(prodList.Count);

        // Java: .get(2) -> C#: [2] (Índice directo)
        string thirdProd = prodList[2].Text;
        Console.WriteLine(thirdProd);

        // Validar que la lista esté vacía
        // C# no tiene .isEmpty() nativo en IReadOnlyCollection, usamos .Count == 0
        bool badgeVisible = driver.FindElements(By.ClassName("shopping_cart_badge")).Count == 0;

        Assert.IsTrue(badgeVisible);
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
