using System;

namespace Proyecto_7_Musica
{
    internal class Program
    {
        static Listacircular playlist = new Listacircular();

        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("=== REPRODUCTOR ===");
                Console.WriteLine("1. Agregar cancion");
                Console.WriteLine("2. Siguiente");
                Console.WriteLine("3. Mostrar playlist");
                Console.WriteLine("0. Salir");

                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Cancion");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Artista");
                        string artista = Console.ReadLine();

                        playlist.Agregar(new Cancion(nombre, artista));
                        break;

                    case 2:
                        playlist.Siguiente();
                        Console.ReadKey();
                        break;

                    case 3:
                        playlist.Mostrar();
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 0);
        }
    }

}
