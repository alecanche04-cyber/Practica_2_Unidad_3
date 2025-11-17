using System;

public class JuegoAdivinanza
{
	public void EjecutarAdivinanza()
	{
		var rnd = new Random();
		while (true) // Bucle para nuevos juegos
		{
			int objetivo = rnd.Next(0, 10001); // número secreto entre 0 y 10000    
			int puntos = 20;
			Console.WriteLine("Adivine un número. Usted empieza con 20 puntos."); // Mensaje inicial

			while (true)
			{
				Console.Write("Teclee un número: "); // Solicitar intento 
				string linea = Console.ReadLine() ?? ""; // Leer entrada
				if (!int.TryParse(linea, out int intento)) // Validar entrada
				{
					Console.WriteLine("Entrada no válida, intenta otra vez."); // Mensaje de error
					continue; // Volver a pedir intento 
				}

				// Restar un punto por el intento (incluye el intento ganador)
				puntos--;

				if (intento < objetivo) // Indicar si es arriba o abajo
				{
					Console.WriteLine($"{intento} - ARRIBA - Ahora tiene {puntos} puntos"); // Mensaje de pista
				}
				else if (intento > objetivo)
				{
					Console.WriteLine($"{intento} - ABAJO - Ahora tiene {puntos} puntos"); // Mensaje de pista
				}
				else
				{
					Console.WriteLine($"{intento} - ADIVINASTE - Usted terminó con {puntos} puntos"); // Mensaje de victoria
					break; // salir del bucle de intentos
				}
			}

			Console.WriteLine("Oprima cualquier tecla para iniciar un nuevo juego"); // mensaje para nuevo juego
			Console.ReadKey(true);
			Console.WriteLine(); // línea en blanco antes del siguiente juego
		}
	}
}

