namespace SeleniumCSharp.CSharpExercises;

[TestClass]
public class Loops
{
    [TestMethod]
    public void LoopsTest()
    {
        // For
        Console.WriteLine("Ciclo for:");
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Iteracion: " + i);
        }

        // While
        Console.WriteLine("\nCiclo while:");
        int j = 1;
        while (j <= 5)
        {
            Console.WriteLine("Contador: " + j);
            j++;
        }

        // Do-while
        Console.WriteLine("\nCiclo do while");
        int k = 100;
        do
        {
            Console.WriteLine("Numero: " + k);
            k++;
        } while (k <= 5);

        // For each
        Console.WriteLine("\nCiclo for-each");

        // DIFERENCIA 1: Inicialización de listas
        // En Java: Arrays.asList(...)
        // En C#: new List<string> { ... }
        List<string> frutas = new List<string> { "Manzana", "Banana", "Cereza", "Pera" };

        // DIFERENCIA 2: Sintaxis del bucle
        // En Java: for (String item : lista)
        // En C#: foreach (string item in lista)
        foreach (string fruta in frutas)
        {
            Console.WriteLine("Fruta: " + fruta);
        }
    }
}
