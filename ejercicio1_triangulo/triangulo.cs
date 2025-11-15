
using System; // Namespace para el programa del triángulo
class ProgramaTriangulo // Definición de la clase principal
{ // Inicio de la clase
    static void Main() // Método principal
    { // Inicio del método principal
        bool continuar = true; // Variable para controlar el bucle
        while (continuar) // Bucle para permitir múltiples cálculos
        { // Inicio del bucle
            Console.WriteLine("Ingrese los tres lados del triangulo: "); // Solicita al usuario los lados del triángulo
            
            Console.WriteLine("Lado A: "); // Solicita el lado A
            double ladoA = Convert.ToDouble(Console.ReadLine()); // Lee y convierte el lado A

            Console.WriteLine("Lado B: "); // Solicita el lado B
            double ladoB = Convert.ToDouble(Console.ReadLine()); // Lee y convierte el lado B

                        Console.WriteLine("Lado C: "); // Solicita el lado C
                        double ladoC = Convert.ToDouble(Console.ReadLine()); // Lee y convierte el lado C
            
                        // Verifica si los lados pueden formar un triángulo
                        if (ladoA + ladoB > ladoC && ladoA + ladoC > ladoB && ladoB + ladoC > ladoA)

                        { // tipo de tiangulo que es
                            if (ladoA == ladoB && ladoB == ladoC) // Verifica si es equilátero
                                Console.WriteLine("El triangulo es equilatero."); // Imprime el tipo de triángulo
                            else if (ladoA == ladoB || ladoA == ladoC || ladoB == ladoC) // Verifica si es isósceles
                                Console.WriteLine("El triangulo es isosceles."); // Imprime el tipo de triángulo
                            else // Si no es equilátero ni isósceles, es escaleno
                                Console.WriteLine("El triangulo es escaleno."); // Imprime el tipo de triángulo

                                // Verifica si es un triángulo rectángulo
                                double[] lados = { ladoA, ladoB, ladoC }; // Crea un arreglo con los lados
                                Array.Sort(lados); // Ordena los lados

                                double a = lados[0], b = lados[1], c = lados[2]; // Asigna los lados ordenados

                                if (Math.Abs(a * a + b * b -c * c) < 0.0001) // Verifica el teorema de Pitágoras
                                    Console.WriteLine("El triangulo es rectangulo."); // Imprime si es rectángulo
                                else
                                    Console.WriteLine("El triangulo no es rectangulo."); // Imprime si no es rectángulo
                        }
                        else // Si no pueden formar un triángulo
                        {
                            Console.WriteLine("Los lados ingresados no forman un triangulo valido."); // Imprime mensaje de error
                        }
                        // Pregunta al usuario si desea continuar
                        Console.WriteLine("¿Desea calcular otro triángulo? (si/no): "); // Solicita continuar
                        string respuesta = Console.ReadLine().ToLower(); // Lee la respuesta y la convierte a minúsculas
                        continuar = (respuesta == "si"); // Actualiza la variable de control del bucle
                        Console.WriteLine(); // Imprime una línea en blanco para separar las iteraciones
        } // Fin del bucle
        Console.WriteLine("Gracias por usar el programa de triángulos."); // Mensaje de despedida
    } // Fin del método principal
} // Fin de la clase