namespace SeleniumCSharp.CSharpExercises
{
    [TestClass]
    public class DataTypes
    {
        [TestMethod]
        public void dataTypesTest()
        {
            byte diasSemena = 7;
            short estudiantes = 150;
            int poblacion = 1000000;
            long distanciaGalaxia = 9460730472580800L;
            float temperature = 36.6f;
            double pi = 3.14159265358979;
            char letraInicial = 'S';
            bool aprobado = true; // En C# se usa 'bool', no 'boolean'

            Console.WriteLine("Dias de la semana: " + diasSemena);
            Console.WriteLine("Numero de estudiantes: " + estudiantes);
            Console.WriteLine("Poblacion: " + poblacion);
            Console.WriteLine("Discancia a otra galaxa en Km: " + distanciaGalaxia);
            Console.WriteLine("Temparatura corporal: " + temperature);
            Console.WriteLine("Valor de PI: " + pi);
            Console.WriteLine("Letra inicial: " + letraInicial);
            Console.WriteLine("Aprobado?: " + aprobado);
        }
}
}
