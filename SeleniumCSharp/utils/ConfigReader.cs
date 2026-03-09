using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharp.utils
{
    public class ConfigReader
    {
        // En C# usamos un Diccionario para guardar los pares Clave-Valor en memoria
        private static readonly Dictionary<string, string> properties = new Dictionary<string, string>();

        // Constructor estático (se ejecuta una vez)
        static ConfigReader()
        {
            try
            {
                // Subimos 3 niveles para leer directo desde el Solution Explorer
                string binDirectory = AppDomain.CurrentDomain.BaseDirectory;
                //string projectRoot = Path.GetFullPath(Path.Combine(binDirectory, @"..\..\..\"));

                // Asumimos que tienes un archivo config.properties en la raíz de tu proyecto
                string filePath = Path.Combine(binDirectory, "config.properties");

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("No se encontró el archivo de configuración en: " + filePath);
                }

                // Leemos todas las líneas del archivo
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    // Ignoramos líneas vacías o comentarios (que en .properties empiezan con #)
                    if (!string.IsNullOrWhiteSpace(line) && !line.TrimStart().StartsWith("#"))
                    {
                        // Separamos por el primer signo '='
                        int separatorIndex = line.IndexOf('=');
                        if (separatorIndex > 0)
                        {
                            string key = line.Substring(0, separatorIndex).Trim();
                            string value = line.Substring(separatorIndex + 1).Trim();

                            // Guardamos en el diccionario
                            properties[key] = value;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cargando config.properties: " + e.Message);
                throw;
            }
        }

        // Método Get en PascalCase
        public static string Get(string key)
        {
            // TryGetValue es la forma segura y eficiente de buscar en diccionarios en C#
            if (properties.TryGetValue(key, out string value))
            {
                return value;
            }

            // Si alguien pide una llave que no existe, es mejor fallar rápido
            throw new KeyNotFoundException($"La llave '{key}' no se encontró en el archivo config.properties");
        }
    }
}
