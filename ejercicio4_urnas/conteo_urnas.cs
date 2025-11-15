public class ConteoUrnas
{
    public int pedirVotos()
    {
        int votoP1,votoP2,votoP3,votoP4,votoP5,votoNulo = 0;
        int Condicion_Salida = 0;
        Console.WriteLine($"Ingrese la cantidad de votos para el Partido: ");
        string stringEntrada = Console.ReadLine();
        if (stringEntrada != null)
        {
            if(stringEntrada == "P1")
            
            {
                Console.WriteLine("Candidato 1 seleccionado.");
                votoP1 =+ 1;
                return votoP1;
            }
            else if(stringEntrada == "P2")
            {
                Console.WriteLine("Candidato 2 seleccionado.");
                votoP2 =+ 1;
                return votoP2;
            }
            else if(stringEntrada == "P3")
            {
                Console.WriteLine("Candidato 3 seleccionado.");
                votoP3 =+ 1;
                return votoP3;
            }
            else if (stringEntrada == "P4")
            {
                Console.WriteLine("Candidato 4 seleccionado.");
                votoP4 =+ 1;
                return votoP4;
            }
            else if (stringEntrada == "P5")
            {
                Console.WriteLine("Candidato 5 seleccionado.");
                votoP5 =+ 1;
                return votoP5;
            }
            else if (stringEntrada == "*")
            {
                Console.WriteLine("Realizando conteo...");
                Condicion_Salida =+ 1;
                return Condicion_Salida;
            }
            else
            {
            Console.WriteLine("Entrada inválida. Se asignarán 0 votos.");
            votoNulo =+ 1;
            return votoNulo;
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Se asignarán 0 votos.");
            return 0;
        }
    }

    public void conteoFinal(int votoP1, int votoP2, int votoP3, int votoP4, int votoP5, int votoNulo)
    {
        Console.WriteLine("Conteo final de votos:");
        Console.WriteLine($"Candidato 1 (P1): {votoP1} votos");
        Console.WriteLine($"Candidato 2 (P2): {votoP2} votos");
        Console.WriteLine($"Candidato 3 (P3): {votoP3} votos");
        Console.WriteLine($"Candidato 4 (P4): {votoP4} votos");
        Console.WriteLine($"Candidato 5 (P5): {votoP5} votos");
        Console.WriteLine($"Votos nulos: {votoNulo} votos");
        
    }

public void calcularPorcentajes(int votoP1, int votoP2, int votoP3, int votoP4, int votoP5, int votoNulo)
    {
        int totalVotos = votoP1 + votoP2 + votoP3 + votoP4 + votoP5 + votoNulo;
        if (totalVotos == 0)
        {
            Console.WriteLine("No se emitieron votos.");
            return;
        }
        double porcentajeP1 = (double)votoP1 / totalVotos * 100;
        double porcentajeP2 = (double)votoP2 / totalVotos * 100;
        double porcentajeP3 = (double)votoP3 / totalVotos * 100;
        double porcentajeP4 = (double)votoP4 / totalVotos * 100;
        double porcentajeP5 = (double)votoP5 / totalVotos * 100;
        double porcentajeNulo = (double)votoNulo / totalVotos * 100; 
    }

public void mostrarPorcentajes(double porcentajeP1, double porcentajeP2, double porcentajeP3, double porcentajeP4, double porcentajeP5, double porcentajeNulo)
    {
        Console.WriteLine("Porcentajes de votos:");
        Console.WriteLine($"Candidato 1 (P1): {porcentajeP1:F2}%");//F2 sirve para limitar a 2 decimales
        Console.WriteLine($"Candidato 2 (P2): {porcentajeP2:F2}%");
        Console.WriteLine($"Candidato 3 (P3): {porcentajeP3:F2}%");
        Console.WriteLine($"Candidato 4 (P4): {porcentajeP4:F2}%");
        Console.WriteLine($"Candidato 5 (P5): {porcentajeP5:F2}%");
        Console.WriteLine($"Votos nulos: {porcentajeNulo:F2}%");
    }
    public void determinarGanador(int votoP1, int votoP2, int votoP3, int votoP4, int votoP5)
    {
        int maxVotos = Math.Max(votoP1, Math.Max(votoP2, Math.Max(votoP3, Math.Max(votoP4, votoP5))));//math max sirve para comparar varios valores y devolver el mayor
        Console.WriteLine("El ganador es el candidato con " + maxVotos + " votos.");
    }

}