using static SeleniumCSharp.CSharpExercises.Abstraction;

namespace SeleniumCSharp.CSharpExercises;

[TestClass]
public class Polymorphism
{
    [TestMethod]
    public void PolymorphismTest()
    {
        // 1. Instancia de la Lista
        // Java: new ArrayList<>();
        // C#:   new List<Figure>();
        // NOTA: En C# no usamos "ArrayList" para listas genéricas.
        List<Figure> figuras = new List<Figure>();

        // 2. Agregar elementos (Add en mayúscula)
        figuras.Add(new Circulo(3));
        figuras.Add(new Cuadrado(4));

        // 3. Iterar (foreach)
        // Java: for (Figure f : figuras)
        // C#:   foreach (Figure f in figuras)
        foreach (Figure f in figuras)
        {
            // Polimorfismo: Llama a la implementación específica de cada hijo
            f.Dibujar();
            Console.WriteLine("Area: " + f.CalcularArea());
        }
    }
}
