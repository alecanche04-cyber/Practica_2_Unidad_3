using System.Runtime.InteropServices;

public class CajaTienda
{

    float montoAcumulado = 0;
    public void Main_cajaTienda ()
    {

    // Solicitar datos al usuario
    Console.WriteLine("El producto es: ");
    string nombreProducto=Console.ReadLine();
    Console.WriteLine("El precio del producto es: ");
    float precioDelProducto=float.Parse(Console.ReadLine());
    Console.WriteLine("El tipo de transacción (+, -, *): ");
    string entrada=Console.ReadLine();
    //llamar a la funcion de limpieza de pantalla
    Console.Clear();
    // Llamar al método para mostrar los  datos
    MostrarDatos(montoAcumulado, nombreProducto, precioDelProducto, entrada);
    Console.WriteLine("Desea añadir otro producto? (si/no): ");
    string respuesta=Console.ReadLine();
    //Inicio de ciclo segun sea el caso
    Boolean Validacion_Pago = true;
    while (Validacion_Pago)
    {
        if (respuesta == "si") //si la respuesta es si, se vuelve a llamar al metodo principal para agregar otro producto
        {
        Main_cajaTienda();
        }
        else //de lo contrario, se procede a solicitar el pago del cliente
        {

            Console.WriteLine("Ingrese el pago del cliente: ");
            float pagoDelCliente=PagoCliente(montoAcumulado);
            float cambio=Cambio(montoAcumulado, pagoDelCliente);
            if (cambio < 0)
            {
                Console.WriteLine("El monto pagado por el cliente es insuficiente.");
            }
            else
            {
                Console.WriteLine("El pago es de: " + pagoDelCliente);
                Console.WriteLine($"El cambio a entregar al cliente es: {cambio}");
                Validacion_Pago = false;
                Console.WriteLine("desea iniciar una nueva transacción? (si/no): ");
                string nuevaTransaccion=Console.ReadLine();
                if (nuevaTransaccion == "si") //si la respuesta es si, se vuelve a llamar al metodo principal para iniciar una nueva transaccion
                {
                    montoAcumulado = 0; //reiniciar el monto acumulado para la nueva transaccion
                    Main_cajaTienda();
                
                }
                else
                {
                    Console.WriteLine("Gracias por usar el sistema de caja de la tienda. ¡Hasta luego!");
                    //esperar unos segundos antes de cerrar el programa
                    System.Threading.Thread.Sleep(3000);
                    Console.Clear();
                    Validacion_Pago = false;
                }
            }
        }
    } 
    }
    public string TipoDeTransaccion (string entrada, float PrecioDelProducto, ref float montoAcumulado)
    {
        
        if (entrada == "+")
        {
            montoAcumulado += PrecioDelProducto;
            return "+";
        }
        else if (entrada == "-")
        {
            montoAcumulado -= PrecioDelProducto;
            return "-";
        }
        else if (entrada == "*")
        {
            montoAcumulado += PrecioDelProducto;
            return "*";
        }
        else
        {
            return "Tipo de transaccion inválido";
        }
    }
    public void MostrarDatos (float montoAcumulado , string nombreProducto, float precioDelProducto, string entrada)
    {
    string tipoDeTransaccion = TipoDeTransaccion(entrada, precioDelProducto, ref montoAcumulado);
    Console.WriteLine($" | Transacción: {tipoDeTransaccion} | Producto: {nombreProducto} | Precio: {precioDelProducto}| Monto acumulado: {montoAcumulado}");
    }
    public float PagoCliente (float precioDelProducto)
    {
        Console.WriteLine("Ingrese el monto con el que paga el cliente: ");
        float pagoDelCliente = float.Parse(Console.ReadLine());
        return pagoDelCliente;
    }
    public float Cambio (float montoAcumulado, float pagoDelCliente)
    {
        float cambio = pagoDelCliente - montoAcumulado;
        return cambio;
    }
    


    
}