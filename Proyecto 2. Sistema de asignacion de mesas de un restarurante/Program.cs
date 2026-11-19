using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2_Restaurante
{
    internal class Program
    {
        static Cola espera = new Cola(); // Instancia la cola para gestionar la lista de espera del restaurante

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear(); // Limpia la pantalla en cada iteración del menú

                Console.WriteLine("=== RESTAURANTE ===");
                Console.WriteLine("1. Agregar cliente");
                Console.WriteLine("2. Asignar mesa");
                Console.WriteLine("3. Mostrar espera");
                Console.WriteLine("0. Salir");
                Console.Write("Opcion: ");

                if (int.TryParse(Console.ReadLine(), out opcion)) // Valida que la opción ingresada sea numérica
                {
                    switch (opcion)
                    {
                        case 1:
                            Agregar(); // Llama a la función para registrar un nuevo cliente
                            break;

                        case 2:
                            AsignarMesa(); // Llama a la función para sacar al cliente de la cola y asignarle mesa
                            break;

                        case 3:
                            espera.Mostrar(); // Muestra la lista de clientes en espera
                            Console.WriteLine("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            break;

                        case 0:
                            Console.WriteLine("Saliendo del sistema..."); // Termina la ejecución del programa
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.ReadKey();
                }

            } while (opcion != 0); // El ciclo se repite mientras la opción no sea 0 (Salir)
        }

        static void Agregar()
        {
            Console.Clear();
            Console.WriteLine("--- Agregar Cliente ---");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? string.Empty; // Lee el nombre del cliente o familia

            Console.Write("Numero de personas: ");
            int personas = int.Parse(Console.ReadLine() ?? "0"); // Lee la cantidad de personas del grupo

            espera.Encolar(new Cliente(nombre, personas)); // Crea el objeto cliente y lo añade a la cola

            Console.WriteLine("\nCliente agregado con éxito.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void AsignarMesa()
        {
            Console.Clear();
            Console.WriteLine("--- Asignar Mesa ---");

            Cliente? cliente = espera.Desencolar(); // Remueve al primer cliente de la fila de espera

            if (cliente == null)
            {
                Console.WriteLine("No hay clientes en espera."); // Si la cola está vacía
            }
            else
            {
                Console.WriteLine($"Mesa asignada al cliente: {cliente}"); // Muestra el cliente atendido
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}