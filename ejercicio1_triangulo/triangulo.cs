
using System;

class TriangleProgram 
{
    public static void TriangleMain() 
    {
        string continuar = "si"; // Variable para controlar el bucle

        while (continuar == "si") // Bucle para permitir múltiples pruebas
        {
            Console.WriteLine("Ingrese los tres lados del triángulo:"); // Solicitar los lados del triángulo
            Console.Write("Lado A: ");
            double ladoA = double.Parse(Console.ReadLine() ?? "0"); // Leer lado A

            Console.Write("Lado B: ");
            double ladoB = double.Parse(Console.ReadLine() ?? "0"); // Leer lado B

            Console.Write("Lado C: ");
            double ladoC = double.Parse(Console.ReadLine() ?? "0"); // Leer lado C

            // Verificar si es un triángulo válido
            if (ladoA + ladoB > ladoC && ladoA + ladoC > ladoB && ladoB + ladoC > ladoA) // Desigualdad triangular
            {
                // Clasificar por tipo
                if (ladoA == ladoB && ladoB == ladoC) // Todos los lados iguales
                    Console.WriteLine("El triángulo es EQUILÁTERO"); // Todos los lados iguales
                else if (ladoA == ladoB || ladoA == ladoC || ladoB == ladoC) // Dos lados iguales
                    Console.WriteLine("El triángulo es ISÓSCELES"); // Dos lados iguales
                else
                    Console.WriteLine("El triángulo es ESCALENO"); // Todos los lados diferentes

                // Verificar si es rectángulo
                double[] lados = { ladoA, ladoB, ladoC }; // Arreglo para ordenar los lados
                Array.Sort(lados);

                if (Math.Abs(lados[0] * lados[0] + lados[1] * lados[1] - lados[2] * lados[2]) < 0.01) // Teorema de Pitágoras 
                    Console.WriteLine("Es un triángulo RECTÁNGULO"); // Es un triángulo rectángulo
                else
                    Console.WriteLine("NO es un triángulo rectángulo"); // No es un triángulo rectángulo
            }
            else
            {
                Console.WriteLine("Los lados no forman un triángulo válido"); // No es un triángulo válido
            }

            Console.WriteLine("\n¿Desea probar con otras medidas? (si/no): "); // Preguntar si desea continuar
            continuar = (Console.ReadLine() ?? "no").ToLower(); // Leer respuesta del usuario
            Console.WriteLine(); // Salto de línea para mejor formato
        }

        Console.WriteLine("Fin del programa"); // Mensaje de fin de programa
    }
}