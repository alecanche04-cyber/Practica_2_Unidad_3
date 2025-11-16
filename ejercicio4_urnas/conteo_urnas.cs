public class ConteoUrnas
{
    // Lee una entrada del usuario y la devuelve (P1..P5, * para terminar)
    public string pedirVotos()
    {
        Console.WriteLine("Ingrese voto (P1,P2,P3,P4,P5, * para terminar):");
        string? entrada = Console.ReadLine();
        return entrada ?? string.Empty;
    }

    // Punto de entrada para ejecutar el conteo desde este archivo
    public void Main_conteoUrnas()
    {
        var urnas = new ConteoUrnas();
        int votoP1 = 0, votoP2 = 0, votoP3 = 0, votoP4 = 0, votoP5 = 0, votoNulo = 0;

        Console.WriteLine("Iniciando captura de votos. Escriba '*' para finalizar y mostrar el conteo.");
        while (true)
        {
            string entrada = urnas.pedirVotos().Trim();
            if (string.IsNullOrEmpty(entrada))
            {
                Console.WriteLine("Entrada inválida. Intente de nuevo.");
                continue;
            }

            if (entrada == "*")
            {
                Console.WriteLine("Realizando conteo...");
                break;
            }

            switch (entrada.ToUpper())
            {
                case "P1":
                    votoP1++;
                    break;
                case "P2":
                    votoP2++;
                    break;
                case "P3":
                    votoP3++;
                    break;
                case "P4":
                    votoP4++;
                    break;
                case "P5":
                    votoP5++;
                    break;
                default:
                    votoNulo++;
                    break;
            }
        }

        urnas.conteoFinal(votoP1, votoP2, votoP3, votoP4, votoP5, votoNulo);
        urnas.calcularPorcentajes(votoP1, votoP2, votoP3, votoP4, votoP5, votoNulo);
        urnas.determinarGanador(votoP1, votoP2, votoP3, votoP4, votoP5);
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