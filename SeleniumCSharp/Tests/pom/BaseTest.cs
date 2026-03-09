using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumCSharp.pages;
using SeleniumCSharp.utils;
using SeleniumTests.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharp.Tests.pom
{
    [TestClass] // Necesario en MSTest para que ejecute los métodos Initialize/Cleanup
    public class BaseTest
    {
        protected IWebDriver driver;

        // --- NUEVO: Objetos para el reporte ---
        protected ExtentTest testNode; // Representa la prueba actual en el reporte

        // 🚨 PROPIEDAD MÁGICA DE MSTEST 🚨
        // MSTest llenará esto automáticamente. ¡Debe llamarse exactamente 'TestContext'!
        public TestContext TestContext { get; set; }

        // Marcados como protected para usarlos directamente en las clases hijas
        protected LoginPage login;
        protected InventoryPage inventory;
        protected MenuPage menu;
        protected CartPage cart;
        protected CheckoutPage checkout;
        protected CheckoutCompletePage checkComplete;

        public IWebDriver GetDriver()
        {
            return driver;
        }

        [TestInitialize] // Equivalente a @BeforeMethod en TestNG
        public void SetUp()
        {
            // 1. Crear la prueba en el reporte ANTES de que empiece
            // Usamos TestContext.TestName para obtener el nombre del [TestMethod] automáticamente
            testNode = ReportManager.Instance.CreateTest(TestContext.TestName);
            testNode.Info("Iniciando la prueba y abriendo el navegador...");

            // Inicializa el driver (asegúrate de que InitializeDriver esté en PascalCase en C#)
            driver = DriverFactory.InitializeDriver();

            // Instancia las páginas
            login = new LoginPage(driver);
            inventory = new InventoryPage(driver);
            menu = new MenuPage(driver);
            cart = new CartPage(driver);
            checkout = new CheckoutPage(driver);
            checkComplete = new CheckoutCompletePage(driver);

            // Navega a la URL
            //DriverFactory.LaunchUrl("https://www.saucedemo.com/");
            DriverFactory.LaunchUrl(ConfigReader.Get("baseUrl"));
        }

        [TestCleanup] // Equivalente a @AfterMethod en TestNG
        public void TearDown()
        {
            // 2. Evaluamos cómo le fue a la prueba gracias a TestContext
            var status = TestContext.CurrentTestOutcome;

            if (status == UnitTestOutcome.Failed)
            {
                // Si falló, tomamos captura de pantalla en Base64 (más limpio que guardar un archivo físico)
                string screenshotBase64 = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;

                // Adjuntamos la captura al reporte
                testNode.Fail($"La prueba falló. Error: {TestContext.FullyQualifiedTestClassName}",
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotBase64).Build());
            }

            else if (status == UnitTestOutcome.Passed)
            {
                testNode.Pass("La prueba finalizó exitosamente.");
            }

            if (driver != null)
            {
                driver.Quit();     // Cierra las ventanas del navegador
                driver.Dispose();  // 💡 C#: Libera el proceso ChromeDriver.exe de la memoria
            }
        }
    }
}
