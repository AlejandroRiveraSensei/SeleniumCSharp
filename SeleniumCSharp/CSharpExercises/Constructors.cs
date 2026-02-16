namespace SeleniumCSharp.CSharpExercises;

[TestClass]
public class Constructors
{
    [TestMethod]
    public void ConstructorsTest()
    {
       // Instanciación del objeto
       Alumno sensei = new Alumno("Alejandro", 33);
       sensei.Presentarse();

       Alumno alumno = new Alumno("Andrea", 22);
       alumno.Presentarse();
    }

    public class Alumno
    {
        // Campos (En C# suelen ser Propiedades, ver nota abajo)
        public string nombre;
        public int edad;

        // Constructor
        public Alumno(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        // Método
        public void Presentarse()
        {
            // Uso de interpolación de cadenas ($"...")
            Console.WriteLine($"Hola, soy {nombre} y tengo {edad} años.");
        }
    }
}
