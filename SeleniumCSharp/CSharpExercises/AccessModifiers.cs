namespace SeleniumCSharp.CSharpExercises;

[TestClass]
public class AccessModifiers
{
    [TestMethod]
    public void AccessModifiersTest()
    {
        {
            Cuenta cuenta = new Cuenta("Sensei", 1000.00);
            // En C# los métodos públicos empiezan con Mayúscula
            cuenta.MostrarSaldo();
        }
    }

    public class Cuenta
    {
        // Campos privados (solo accesibles dentro de esta clase)
        private string titular;
        private double saldo;

        // Constructor
        public Cuenta(string titular, double saldo)
        {
            this.titular = titular;
            this.saldo = saldo;
        }

        // Método público (accesible desde fuera)
        // Convención C#: PascalCase (MostrarSaldo)
        public void MostrarSaldo()
        {
            Console.WriteLine("Titular: " + titular);
            // Formato de moneda simple con interpolación
            Console.WriteLine($"Saldo disponible: ${saldo}");
        }
    }
}
