namespace SeleniumCSharp.CSharpExercises;

[TestClass]
public class ListAndArrays
{
    [TestMethod]
    public void ListAndArraysTest()
    {
        // --- Arreglo fijo ---
        string[] colores = { "rojo", "verde", "azul" };

        Console.WriteLine("Arreglo:");
        // NOTA: En Java es .length (minúscula), en C# es .Length (Mayúscula)
        for (int i = 0; i < colores.Length; i++)
        {
            Console.WriteLine("Color[" + i + "]: " + colores[i]);
        }


        // --- Lista Dinámica ---
        // Java: List<String> x = new ArrayList<>();
        // C#:   List<string> x = new List<string>();
        List<string> animales = new List<string>();

        // Los métodos en C# empiezan con Mayúscula (.Add, .Remove)
        animales.Add("perro");
        animales.Add("gato");
        animales.Add("loro");

        Console.WriteLine("\nLista: ");
        // Java: for (String animal : animales)
        // C#:   foreach (string animal in animales)
        foreach (string animal in animales)
        {
            Console.WriteLine("Animal: " + animal);
        }

        animales.Remove("gato");
        animales.Add("conejo");

        Console.WriteLine("\nLista Actualizada: ");
        foreach (string animal in animales)
        {
            Console.WriteLine("Animal: " + animal);
        }
    }
}
