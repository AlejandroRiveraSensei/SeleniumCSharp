namespace SeleniumCSharp.CSharpExercises;

[TestClass]
public class Methods
{
    [TestMethod]
    public void MethodsTest()
    {
        // Llamada a los métodos (notar la Mayúscula inicial)
        Saludar("Rivera");

        int resultado = Sumar(120, 230, 300);
        Console.WriteLine("suma: " + resultado);
    }

    // void: no retorna valor
    public static void Saludar(string apellido)
    {
        Console.WriteLine("Hola, " + apellido + "!");
    }

    // int: retorna un entero
    public static int Sumar(int a, int b)
    {
        return a + b;
    }

    // Sobrecarga (Overloading): mismo nombre, distintos parámetros
    public static int Sumar(int a, int b, int c)
    {
        return a + b + c;
    }

    // Esto reemplaza a los dos métodos anteriores
    //public static int Sumar(int a, int b, int c = 0) // c es 0 si no se envía
    //{
    //    return a + b + c;
    //}
}
