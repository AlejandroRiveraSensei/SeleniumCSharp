namespace SeleniumCSharp.CSharpExercises;

[TestClass]
public class Inheritance
{
    [TestMethod]
    public void InheritanceTest()
    {
        Perro miPerro = new Perro("Solovino");

        // En C# los métodos empiezan con Mayúscula
        miPerro.Hablar();
        miPerro.Dormir();
    }

    // Clase Base (Padre)
    public class Animal
    {
        public void Dormir()
        {
            Console.WriteLine("El animal duerme...");
        }
    }

    // Clase Derivada (Hija)
    // En Java: class Perro extends Animal
    // En C#:   class Perro : Animal
    public class Perro : Animal
    {
        private string nombre;

        public Perro(string nombre)
        {
            this.nombre = nombre;
        }
        public void Hablar()
        {
            // Concatenación normal o interpolación (más moderno)
            Console.WriteLine(nombre + " dice: Guau!!!");
        }
    }
}
