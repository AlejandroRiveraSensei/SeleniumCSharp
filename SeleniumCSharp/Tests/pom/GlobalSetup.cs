using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumTests.Utils; // Tu namespace de ReportManager

namespace SeleniumTests.Tests
{
    [TestClass] // Necesita el atributo TestClass para que MSTest lo detecte
    public class GlobalSetup
    {
        // Este método se ejecutará UNA SOLA VEZ cuando absolutamente 
        // todos los hilos y todas las pruebas hayan finalizado.
        [AssemblyCleanup]
        public static void GenerarReporteFinal()
        {
            // Escribimos el reporte en el disco de forma segura
            ReportManager.Instance.Flush();
        }
    }
}