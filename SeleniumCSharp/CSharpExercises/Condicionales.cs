namespace SeleniumCSharp.CSharpExercises
{
    [TestClass]
    public class Condicionales
    {
        [TestMethod]
        public void CondicionalesTest() {
            int edad = 15;

            // IF
            if (edad >= 18)
            {
                Console.WriteLine("Eres mayor de edad");
            }

            // If-else
            if (edad < 18)
            {
                Console.WriteLine("Eres menor de edad");
            }
            else
            {
                Console.WriteLine("Tienes al menos 18 años");
            }

            // IF-ELSE-IF
            int calificacion = 69;
            if (calificacion >= 90)
            {
                Console.WriteLine("Excelente");
            }
            else if (calificacion >= 80)
            {
                Console.WriteLine("Muy bien");
            }
            else if (calificacion >= 70)
            {
                Console.WriteLine("Bien");
            }
            else
            {
                Console.WriteLine("Requiere mejora");
            }

            // IF anidado
            bool tieneCuenta = false;
            bool tieneFondos = true;

            if (tieneCuenta)
            {
                if (tieneFondos)
                {
                    Console.WriteLine("Puedes hacer un compra");
                }
                else
                {
                    Console.WriteLine("No tienes fondos suficientes");
                }
            }
            else
            {
                Console.WriteLine("No tienes cuenta registrada");
            }

            // Switch
            int diaSemana = 9;

            switch (diaSemana)
            {
                case 1:
                    Console.WriteLine("Lunes");
                    break;
                case 2:
                    Console.WriteLine("Martes");
                    break;
                case 3:
                    Console.WriteLine("Miercoles");
                    break;
                case 4:
                    Console.WriteLine("Jueves");
                    break;
                case 5:
                    Console.WriteLine("Viernes");
                    break;
                default:
                    Console.WriteLine("Dia invalido");
                    break; // En C#, el break en default es obligatorio si hay código
            }

            string nombreDia = diaSemana switch
            {
                1 => "Lunes",
                2 => "Martes",
                3 => "Miercoles",
                4 => "Jueves",
                5 => "Viernes",
                _ => "Dia invalido" // El guion bajo '_' actúa como default
            };
            Console.WriteLine(nombreDia);

            // Operador ternario
            // NOTA: Java usa 'String', C# prefiere 'string' (minúscula)
            string mensaje = (edad >= 18) ? "Adulto" : "Menor de edad";
            Console.WriteLine("Ternario: " + mensaje);

        }
    }
}
