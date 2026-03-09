using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharp.utils
{
    public class DriverFactory
    {
        // ThreadLocal asegura que cada hilo (thread) tenga su propia instancia de IWebDriver.
        // En C# se inicializa instanciando la clase genérica ThreadLocal<T>
        private static readonly ThreadLocal<IWebDriver> driverThread = new ThreadLocal<IWebDriver>();

        public static IWebDriver GetDriver()
        {
            // En Java usas .get(). En C# usamos la propiedad .Value
            return driverThread.Value;
        }

        // Variable estática clásica (aunque te recomiendo usar solo GetDriver() 
        // si planeas ejecutar tests en paralelo).
        public static IWebDriver driver;

        public static IWebDriver InitializeDriver()
        {
            ChromeOptions options = new ChromeOptions();

            // Preferencias (HashMap en Java -> AddUserProfilePreference en C#)
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

            // Argumentos (Igual en C#, pero con Mayúscula)
            options.AddArgument("--disable-blink-features=AutomationControlled");

            // CI/CD Implementation
            // Java: System.getenv("CI") -> C#: Environment.GetEnvironmentVariable("CI")
            if (Environment.GetEnvironmentVariable("CI") != null)
            {
                options.AddArgument("--headless");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
                options.AddArgument("--remote-allow-origins=*"); // CORS error
                options.AddArgument("--disable-gpu");

                // Java: System.currentTimeMillis() -> C#: DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                options.AddArgument($"--user-data-dir=/tmp/chrome-{timestamp}");
            }

            // Inicializamos el driver
            var newDriver = new ChromeDriver(options);

            // Asignación clásica (Como en tu código original)
            driver = newDriver;

            // ASIGNACIÓN CORRECTA PARA THREADLOCAL (Para paralelización):
            // En Java sería driverThread.set(newDriver)
            driverThread.Value = newDriver;

            return newDriver;
        }

        public static void LaunchUrl(string url)
        {
            // Es más seguro usar GetDriver() aquí en caso de ejecución paralela
            GetDriver().Navigate().GoToUrl(url);
        }
    }
}
