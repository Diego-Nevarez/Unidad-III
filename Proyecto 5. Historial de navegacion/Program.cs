using System;

namespace Proyecto5_Navegador
{
    internal class program
    {
        static Pila atras = new Pila();     // Pila para almacenar el historial de páginas anteriores
        static Pila adelante = new Pila();  // Pila para almacenar el historial de páginas siguientes

        static string actual = "inicio";    // Variable que almacena la página web actual

        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== Navegador === ");
                Console.WriteLine($"Pagina actual: {actual}  ");
                Console.WriteLine("1. Visitar pagina ");
                Console.WriteLine("2. Atras ");
                Console.WriteLine("3. Adelante ");
                Console.WriteLine("0. salir  ");
                Console.WriteLine("opcion ");

                opcion = int.Parse(Console.ReadLine()); // Lee la opción seleccionada por el usuario

                switch (opcion)
                {
                    case 1:
                        atras.Push(actual); // Guarda la página actual en la pila de "atrás" antes de cambiar

                        Console.WriteLine("1. Nueva pagina: ");
                        actual = Console.ReadLine(); // Lee y establece la nueva página visitada

                        // (Nota opcional: aquí usualmente se limpia la pila 'adelante' al visitar una nueva página)
                        break;

                    case 2:
                        String anterior = atras.Pop(); // Saca la última página visitada de la pila "atrás"

                        if (anterior != null)
                        {
                            adelante.Push(actual);     // Guarda la página actual en la pila de "adelante"
                            actual = anterior;         // Restaura la página anterior como actual
                        }
                        break;

                    case 3:
                        string siguiente = adelante.Pop(); // Saca la página de la pila "adelante"
                        if (siguiente != null)
                        {
                            atras.Push(actual);            // Guarda la página actual en la pila de "atrás"
                            actual = siguiente;            // Restaura la página siguiente como actual
                        }
                        break;
                }
            } while (opcion != 0); // El programa se repite hasta que la opción sea 0 (Salir)
        }
    }
}



