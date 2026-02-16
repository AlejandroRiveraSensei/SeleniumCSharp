namespace SeleniumCSharp.CSharpExercises;

[TestClass]
public class Encapsulation
{
    [TestMethod]
    public void EncapTest()
    {
        Persona alejandro = new Persona("Alejandro", 33);

        // LEER (GET):
        // En lugar de alejandro.getNombre(), se accede como si fuera una variable
        Console.WriteLine("Nombre: " + alejandro.Nombre);
        Console.WriteLine("Edad: " + alejandro.Edad);

        // ESCRIBIR (SET):
        // En lugar de alejandro.setEdad(34), se asigna con el signo =
        alejandro.Edad = 34;

        Console.WriteLine("Edad actualizada: " + alejandro.Edad);
    }

    public class Persona
    {
        // 1. Propiedad Auto-implementada (Para el Nombre)
        // Como no tiene lógica especial, C# crea el campo privado por ti automáticamente.
        // 'private set' significa que solo se puede asignar valor dentro de esta clase (inmutable desde fuera).
        public string Nombre { get; private set; }


        // 2. Propiedad Completa (Para la Edad)
        // Como necesitamos lógica (validar > 0), creamos un campo privado de respaldo ("backing field").
        private int _edad;

        public int Edad
        {
            get
            {
                return _edad;
            }
            set
            {
                // 'value' es una palabra clave en C# que representa el valor que intentan asignar
                if (value > 0)
                {
                    _edad = value;
                }
            }
        }

        public Persona(string nombre, int edad)
        {
            // Asignamos a las Propiedades (Mayúscula)
            Nombre = nombre;
            Edad = edad; // Al usar la propiedad, se ejecuta la validación del 'set'
        }
    }
}

