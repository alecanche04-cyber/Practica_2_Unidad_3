using System;
using System.Collections.Generic;

public class CajaTienda
{
    // Monto acumulado de la transacción actual
    private float montoAcumulado = 0f;
    // Lista para mantener los productos agregados (no se borra cuando limpias la pantalla)
    private List<string> productos = new List<string>();

    // Método de entrada sencillo 
    public void Main_cajaTienda()
    {
        while (true)
        {
            // Pedir datos del producto
            Console.Write("Nombre del producto: ");
            string nombreProducto = Console.ReadLine() ?? string.Empty; // Leer nombre del producto empty sirve para evitar null

            float precioDelProducto;
            while (true)
            {
                Console.Write("Precio del producto: ");
                string? precioStr = Console.ReadLine(); // el ? sirve para evitar null
                if (float.TryParse(precioStr, out precioDelProducto) && precioDelProducto >= 0) break; // Validar precio tryparse sirve para evitar excepciones por entrada inválida out sirve para la variable de salida
                Console.WriteLine("Precio inválido. Escribe un número válido (ej: 12.50).");
            }

            Console.Write("Tipo de transacción (+ agregar, - restar, * agregar): ");
            string tipo = (Console.ReadLine() ?? string.Empty).Trim(); // Leer tipo de transacción y evitar null .trim sirve para eliminar espacios en blanco

            // Procesar el producto y añadir la línea a la lista
            ProcesarProducto(nombreProducto, precioDelProducto, tipo);

            // Limpiar pantalla y volver a mostrar la lista acumulada (la lista NO se borra)
            Console.Clear();
            Console.WriteLine("--- Productos agregados ---");
            foreach (var linea in productos) // Mostrar cada línea de producto
            {
                Console.WriteLine(linea);
            }
            Console.WriteLine(); // Línea en blanco para separar

            // Preguntar si se quiere agregar otro producto
            Console.Write("¿Desea añadir otro producto? (si/no): ");
            string respuesta = (Console.ReadLine() ?? "no").Trim().ToLower(); // Evitar null, eliminar espacios y pasar a minúsculas
            if (respuesta == "si")
            {
                // continuar agregando
                continue;
            }

            // Procesar pago: preguntar hasta que el cliente pague suficiente o cancele
            float pagoDelCliente = 0f;
            while (true)
            {
                Console.Write($"Monto a pagar: {montoAcumulado:F2}. Ingrese pago del cliente: ");
                string? pagoStr = Console.ReadLine();
                if (!float.TryParse(pagoStr, out pagoDelCliente) || pagoDelCliente < 0)
                {
                    Console.WriteLine("Pago inválido. Intente de nuevo.");
                    continue;
                }

                float cambio = Cambio(montoAcumulado, pagoDelCliente);
                if (cambio < 0)
                {
                    Console.WriteLine($"Pago insuficiente. Faltan {Math.Abs(cambio):F2}.");
                    Console.Write("Desea intentar con otro pago? (si/no): ");
                    string tryAgain = (Console.ReadLine() ?? "no").Trim().ToLower();
                    if (tryAgain == "si")
                    {
                        continue; // volver a pedir el pago
                    }
                    else
                    {
                        Console.WriteLine("Transacción cancelada.");
                        break; // salir del bucle de pago
                    }
                }

                // Pago suficiente
                Console.WriteLine($"Pago recibido: {pagoDelCliente:F2}");
                Console.WriteLine($"Cambio a entregar: {cambio:F2}");
                break;
            }

            // Después del pago (o cancelación) preguntar si desea nueva transacción
            Console.Write("¿Desea iniciar una nueva transacción? (si/no): ");
            string nueva = (Console.ReadLine() ?? "no").Trim().ToLower();
            if (nueva == "si")
            {
                montoAcumulado = 0f;
                productos.Clear();
                Console.Clear();
                continue; // iniciar nueva transacción
            }

            Console.WriteLine("Gracias por usar el sistema de caja. Hasta luego.");
            System.Threading.Thread.Sleep(1200);
            break; // salir del bucle y del método
        }
    }

    // Procesa el producto actual: actualiza el monto acumulado y guarda la línea en la lista
    private void ProcesarProducto(string nombre, float precio, string tipo)
    {
        string etiqueta = "(inv)";
        if (tipo == "+" || tipo == "*")
        {
            montoAcumulado += precio;
            etiqueta = "+";
        }
        else if (tipo == "-")
        {
            montoAcumulado -= precio;
            etiqueta = "-";
        }

        string linea = $"Producto: {nombre} | Precio: {precio:F2} | Transacción: {etiqueta} | Monto acumulado: {montoAcumulado:F2}";
        productos.Add(linea);
    }

    // Calcula el cambio
    private float Cambio(float monto, float pago)
    {
        return pago - monto;
    }
}