using System;

class JuegoAdivinanza
{
	public static void Main()
	{
		var rnd = new Random();
		while (true)
		{
			int objetivo = rnd.Next(0, 10001); // número secreto entre 0 y 10000
			int puntos = 20;
			Console.WriteLine("Adivine un número. Usted empieza con 20 puntos.");

			while (true)
			{
				Console.Write("Teclee un número: ");
				string linea = Console.ReadLine() ?? "";
				if (!int.TryParse(linea, out int intento))
				{
					Console.WriteLine("Entrada no válida, intenta otra vez.");
					continue;
				}

				// Restar un punto por el intento (incluye el intento ganador)
				puntos--;

				if (intento < objetivo)
				{
					Console.WriteLine($"{intento} - ARRIBA - Ahora tiene {puntos} puntos");
				}
				else if (intento > objetivo)
				{
					Console.WriteLine($"{intento} - ABAJO - Ahora tiene {puntos} puntos");
				}
				else
				{
					Console.WriteLine($"{intento} - ADIVINASTE - Usted terminó con {puntos} puntos");
					break;
				}
			}

			Console.WriteLine("Oprima cualquier tecla para iniciar un nuevo juego");
			Console.ReadKey(true);
			Console.WriteLine(); // línea en blanco antes del siguiente juego
		}
	}
}

