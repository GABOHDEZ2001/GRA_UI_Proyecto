internal class Program
{
    private static void Main(string[] args)
    {
        while (true) // Ciclo para obligar al usuario a elegir una opción válida
        {
            Console.Clear();
            Console.WriteLine("1. Opción Gráfica");
            Console.WriteLine("2. Espiral");
            Console.WriteLine("Elige una de las opciones:");

            if (!int.TryParse(Console.ReadLine(), out int opcion)) // Validar entrada como número entero
            {
                Console.WriteLine("Entrada no válida. Presiona una tecla para intentarlo nuevamente.");
                Console.ReadKey();
                continue; // Reinicia el ciclo
            }

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Has elegido la opción 1");

                    int y = 120, x = 20, ancho = 7, alto = 13;

                    Console.Clear();
                    MostrarTexto(55, 1, "Dibujar gráfico", ConsoleColor.Green);

                    for (int i = 0; i < 10; i++)
                    {
                        // Movimiento en las cuatro direcciones
                        DibujarMovimiento(ref y, ref x, -1, 0, ancho, ConsoleColor.Cyan); // Izquierda
                        DibujarMovimiento(ref y, ref x, 0, -1, alto, ConsoleColor.Blue);  // Abajo
                        DibujarMovimiento(ref y, ref x, -1, 0, ancho, ConsoleColor.Cyan); // Izquierda
                        DibujarMovimiento(ref y, ref x, 0, 1, alto, ConsoleColor.Blue);   // Arriba
                    }

                    MostrarTexto(40, 26, "Listo!!! Presiona una tecla para continuar", ConsoleColor.Green);
                    Console.ReadKey();
                    break;

                case 2:
                    Console.WriteLine("Has elegido la opción 2");

                    y = 64;
                    x = 14;
                    int longitud = 4, altura = 0, direccion = 0;

                    Console.Clear();
                    ConsoleColor[] colores = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.DarkBlue, ConsoleColor.Red, ConsoleColor.Cyan };
                    int colorIndex = 0;

                    for (int e = 0; e < 30; e++)
                    {
                        int pasos = (direccion == 0 || direccion == 2) ? longitud : altura;

                        for (int i = 0; i < pasos; i++)
                        {
                            if (DentroDeLimites(y, x))
                            {
                                Console.SetCursorPosition(y, x);
                                System.Threading.Thread.Sleep(15);
                                Console.ForegroundColor = colores[colorIndex];
                                Console.WriteLine("*");
                            }
                            else
                            {
                                break;
                            }

                            switch (direccion)
                            {
                                case 0: y--; break; // Izquierda
                                case 1: x--; break; // Arriba
                                case 2: y++; break; // Derecha
                                case 3: x++; break; // Abajo
                            }
                            colorIndex = (colorIndex + 1) % colores.Length;
                        }

                        direccion = (direccion + 1) % 4;

                        if (direccion == 0 || direccion == 2) longitud += 5;
                        else if (direccion == 1 || direccion == 3) altura += 2;
                    }

                    Console.SetCursorPosition(40, 28);
                    Console.WriteLine("Presiona una tecla para continuar...");
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("Opción no válida. Presiona una tecla para intentarlo nuevamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void MostrarTexto(int y, int x, string texto, ConsoleColor color)
    {
        Console.SetCursorPosition(y, x);
        Console.ForegroundColor = color;
        Console.WriteLine(texto);
    }

    static void DibujarMovimiento(ref int y, ref int x, int cambioY, int cambioX, int pasos, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        for (int i = 0; i < pasos; i++)
        {
            y += cambioY;
            x += cambioX;

            if (DentroDeLimites(y, x))
            {
                Console.SetCursorPosition(y, x);
                Console.Write("*");
                System.Threading.Thread.Sleep(15);
            }
        }
    }

    static bool DentroDeLimites(int y, int x) =>
        y >= 0 && y < Console.WindowWidth && x >= 0 && x < Console.WindowHeight;
}
