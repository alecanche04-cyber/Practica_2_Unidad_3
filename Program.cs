internal class Program
{
    private static void Main(string[] args)
    {
        // Menu para seleccionar el ejercicio a ejecutar
        while (true)
        {
            Console.WriteLine("================ Practica Unidad 3 ================");
            Console.WriteLine("Seleccione un ejercicio para ejecutar:");
            Console.WriteLine("1) Ejercicio 1 - Triángulo");
            Console.WriteLine("2) Ejercicio 2 - Recibo CFE");
            Console.WriteLine("3) Ejercicio 3 - Juego Adivinanza");
            Console.WriteLine("4) Ejercicio 4 - Conteo de urnas");
            Console.WriteLine("5) Ejercicio 5 - Caja registradora");
            Console.WriteLine("0) Salir");
            Console.Write("Opción: ");
            string? opcion = Console.ReadLine();
            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(opcion)) // Validar entrada vacía
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.\n");
                continue;
            }

            switch (opcion.Trim())
            {
                case "1":
                    // Triángulo (método estático)
                    TriangleProgram.TriangleMain();
                    break;
                case "2":
                    // Recibo CFE (método estático en namespace Ejercicio2Cfe)
                    Ejercicio2Cfe.ReciboCFE.EjecutarReciboCFE();
                    break;
                case "3":
                    // Juego de adivinanza (método de instancia)
                    var juego = new JuegoAdivinanza();
                    juego.EjecutarAdivinanza();
                    break;
                case "4":
                    // Conteo de urnas (método de instancia)
                    var urnas = new ConteoUrnas();
                    urnas.Main_conteoUrnas();
                    break;
                case "5":
                    // Caja registradora (método de instancia)
                    var caja = new CajaTienda();
                    caja.Main_cajaTienda();
                    break;
                case "0":
                    Console.WriteLine("Saliendo. Hasta luego.");
                    return;
                default:
                    Console.WriteLine("Opción no reconocida. Intente de nuevo.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Presione Enter para volver al menú...");
            Console.ReadLine();
            Console.Clear();
        }
    }

    
}