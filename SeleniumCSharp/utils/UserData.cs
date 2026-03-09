using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace SeleniumCSharp.utils
{
    public class UserData
    {
        private static JsonNode usersJson;

        // Constructor estático en C# (reemplaza al bloque static { } de Java)
        // Se ejecuta una sola vez automáticamente antes de que se use la clase
        static UserData()
        {
            try
            {
                // En C#, para buscar archivos en proyectos de prueba, usamos BaseDirectory.
                // Esto apunta a la carpeta bin/Debug/... donde se ejecuta el test.
                // 1. Obtenemos el directorio de ejecución (ej. /bin/Debug/net8.0)
                string binDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // 2. Subimos 3 niveles hacia atrás (..\..\..\) para llegar a la raíz del proyecto
                //string projectRoot = Path.GetFullPath(Path.Combine(binDirectory, @"..\..\..\"));

                // 3. Armamos la ruta hacia tu carpeta visible en el Solution Explorer
                string filePath = Path.Combine(binDirectory, "testdata", "users.json");

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("El archivo users.json no se encontró en: " + filePath);
                }

                // File.ReadAllText hace todo el trabajo pesado del Scanner de Java en 1 línea
                string content = File.ReadAllText(filePath);

                // Parseamos el string a un objeto JSON
                usersJson = JsonNode.Parse(content);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cargando usersJson: " + e.Message);
                // Es buena práctica lanzar la excepción para que las pruebas fallen
                // inmediatamente si no hay datos, en lugar de dar un falso positivo.
                throw;
            }
        }

        public static string GetUserName(string key)
        {
            // En C#, podemos navegar por el JSON como si fuera un diccionario
            return usersJson[key]["user"].ToString();
        }

        public static string GetPassword(string key)
        {
            return usersJson[key]["password"].ToString();
        }
    }
}
