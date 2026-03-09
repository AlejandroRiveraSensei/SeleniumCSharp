using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SeleniumTests.Utils
{
    public class ReportManager
    {
        private static ExtentReports extent;

        // Propiedad que devuelve la instancia única del reporte
        public static ExtentReports Instance
        {
            get
            {
                if (extent == null)
                {
                    // 1. Obtenemos el directorio actual (bin/Debug/net...)
                    string binDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    // 2. Subimos 3 niveles para llegar a la raíz del proyecto
                    //string projectRoot = Path.GetFullPath(Path.Combine(binDirectory, @"..\..\..\"));

                    // 3. Creamos una ruta para una nueva carpeta "Reports" en la raíz
                    string reportFolder = Path.Combine(binDirectory, "Reports");

                    // 4. Si la carpeta no existe, la creamos dinámicamente
                    if (!Directory.Exists(reportFolder))
                    {
                        Directory.CreateDirectory(reportFolder);
                    }

                    // 5. Definimos la ruta final del archivo HTML
                    string reportPath = Path.Combine(reportFolder, "ReportePruebas.html");

                    // Inicializamos el reportero con la nueva ruta
                    var sparkReporter = new ExtentSparkReporter(reportPath);

                    sparkReporter.Config.DocumentTitle = "Reporte de Automatización SauceDemo";
                    sparkReporter.Config.ReportName = "Resultados E2E";
                    sparkReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

                    extent = new ExtentReports();
                    extent.AttachReporter(sparkReporter);

                    extent.AddSystemInfo("Sistema Operativo", Environment.OSVersion.ToString());
                    extent.AddSystemInfo("Navegador", "Chrome");
                    extent.AddSystemInfo("QA Engineer", "Sensei Alejandro");
                }
                return extent;
            }
        }
    }
}