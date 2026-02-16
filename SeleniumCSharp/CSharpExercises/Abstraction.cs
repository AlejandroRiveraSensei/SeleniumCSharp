namespace SeleniumCSharp.CSharpExercises;

[TestClass]
public class Abstraction
{
    [TestMethod]
    public void TestMethod1()
    {
        // Polimorfismo: Variable de tipo abstracta, instancia concreta
        Figure figure = new Cuadrado(5);

        // Llamada a métodos (Mayúscula inicial en C#)
        figure.Dibujar();
        Console.WriteLine("Area: " + figure.CalcularArea());
    }

    // 1. Clase Abstracta
    public abstract class Figure
    {
        // Métodos abstractos (definen el contrato)
        public abstract void Dibujar();
        public abstract double CalcularArea();
    }

    // 2. Clase Concreta: Circulo
    // 'extends' se convierte en ':'
    public class Circulo : Figure
    {
        private double radio;

        public Circulo(double radio)
        {
            this.radio = radio;
        }

        // DIFERENCIA CRÍTICA:
        // Debes escribir 'override' explícitamente. Si no lo haces, el compilador dará error.
        public override void Dibujar()
        {
            Console.WriteLine("Dibujando un circulo...");
        }

        public override double CalcularArea()
        {
            return Math.PI * radio * radio;
        }
    }

    // 3. Clase Concreta: Cuadrado
    public class Cuadrado : Figure
    {
        private double lado;

        public Cuadrado(double lado)
        {
            this.lado = lado;
        }

        public override void Dibujar()
        {
            Console.WriteLine("Dibujando un cuadrado...");
        }

        public override double CalcularArea()
        {
            return lado * lado;
        }
    }
}
