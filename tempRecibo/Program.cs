using System;

class ReciboCFE
{
    public static void Main()
    {
        string continuar = "si"; // Variable para controlar si seguimos o no

        while (continuar == "si") // Mientras el usuario quiera continuar
        {
            Console.WriteLine("=== SISTEMA DE LECTURA DE MEDIDORES CFE ===\n");

            // Pedir el consumo anterior
            Console.Write("Ingrese el consumo anterior (kwh): ");
            double consumoAnterior = double.Parse(Console.ReadLine() ?? "0"); // Leer consumo anterior

            // Pedir el consumo nuevo
            Console.Write("Ingrese el consumo nuevo (kwh): ");
            double consumoNuevo = double.Parse(Console.ReadLine() ?? "0"); // Leer consumo nuevo

            // Sacar la diferencia entre los dos consumos
            double consumoTotal = consumoNuevo - consumoAnterior;

            // Validar que el consumo nuevo sea mayor al anterior
            if (consumoTotal < 0)
            {
                Console.WriteLine("Error: El consumo nuevo no puede ser menor al anterior.\n"); // Mensaje de error
                continue; // Volver a empezar
            }

            Console.WriteLine("\n=== RECIBO DE CONSUMO DE ENERGÍA ELÉCTRICA ===\n"); // Encabezado del recibo

            // Calcular cuánto hay que pagar por la energía
            double costoEnergia = CalcularCostoEnergia(consumoTotal); // Costo sin impuestos

            // Sacar el 5% de impuesto
            double isc = costoEnergia * 0.05;

            // Sumar la energía y el impuesto
            double subtotal = costoEnergia + isc;

            // Sacar el 16% de IVA sobre el subtotal
            double iva = subtotal * 0.16;

            // Sacar el total final
            double totalFinal = subtotal + iva;

            // Mostrar todo en el recibo
            MostrarRecibo(consumoTotal, costoEnergia, isc, iva, totalFinal); // Función para mostrar el recibo

            Console.WriteLine("\n¿Desea procesar otro recibo? (si/no): "); // Preguntar si desea continuar
            continuar = (Console.ReadLine() ?? "no").ToLower(); // Leer respuesta del usuario
            Console.WriteLine();
        }

        Console.WriteLine("Fin del programa"); // Mensaje de fin de programa
    }

    // Esta función calcula cuánto hay que pagar según los kwh consumidos
    static double CalcularCostoEnergia(double consumo) // Calcula el costo de energía
    {
        double costo = 0;

        // Si consume menos de 1700 kwh es cliente con bajo consumo
        if (consumo < 1700)
        {
            // Tarifa de bajo consumo con 3 niveles de precio
            if (consumo <= 150) // Si usa 150 kwh o menos
            {
                costo = consumo * 0.70; // Todo a $0.70 por kwh
            }
            else if (consumo <= 350) // Si usa entre 151 y 350 kwh
            {
                // Primeros 150 a $0.70 + el resto a $1.20
                costo = (150 * 0.70) + ((consumo - 150) * 1.2);
            }
            else // Si usa más de 350 kwh
            {
                // Primeros 150 a $0.70 + siguientes 200 a $1.20 + el resto a $2.90
                costo = (150 * 0.70) + (200 * 1.2) + ((consumo - 350) * 2.9);
            }
        }
        else
        {
            // Si consume 1700 o más kwh, paga tarifa plana
            costo = consumo * 3.2; // Todo a $3.20 por kwh
        }

        return costo;
    }

    // Esta función imprime el recibo bonito en la pantalla
    static void MostrarRecibo(double consumo, double costoEnergia, double isc, double iva, double totalFinal)
    {
        if (consumo < 1700) // Si es cliente de bajo consumo
        {
            // Mostrar el primer nivel de precio
            double costo1 = 150 * 0.70;
            Console.WriteLine($"Energía: 150 kwh $0.7 pesos x kwh ${costo1:F2}"); // Costo total

            double consumoRestante = consumo - 150; // Cuánto falta por contar

            if (consumoRestante > 0) // Si usó más de 150 kwh
            {
                // Mostrar el segundo nivel de precio
                double consumoNivel2 = Math.Min(consumoRestante, 200); // Máximo 200 kwh
                double costo2 = consumoNivel2 * 1.2;
                Console.WriteLine($"Energía: {consumoNivel2} kwh $1.2 pesos x kwh ${costo2:F2}"); // Costo total

                consumoRestante -= consumoNivel2; // Restar lo que ya contamos

                if (consumoRestante > 0) // Si usó más de 350 kwh
                {
                    // Mostrar el tercer nivel de precio
                    double costo3 = consumoRestante * 2.9; // Costo del resto
                    Console.WriteLine($"Energía: {consumoRestante} kwh $2.9 pesos x kwh ${costo3:F2}"); // Costo total
                }
            }
        }
        else // Si es cliente de alto consumo
        {
            // Mostrar tarifa plana
            double costo = consumo * 3.2; // Costo total
            Console.WriteLine($"Energía: {consumo} kwh $3.2 pesos x kwh ${costo:F2}"); // Costo total
        }

        // Mostrar los totales
        Console.WriteLine($"\nTotal de energía: ${costoEnergia:F2}"); // Total de energía
        Console.WriteLine($"ISC (5%): ${isc:F2}"); // Impuesto especial
        Console.WriteLine($"IVA (16%): ${iva:F2}"); // Impuesto al valor agregado
        Console.WriteLine($"TOTAL: ${totalFinal:F2}"); // Total a pagar
    }
}
