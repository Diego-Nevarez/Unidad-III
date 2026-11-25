using Proyecto1_Clinica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1_Clinica
{
    internal class Menu
    {
        static Cola pacientes = new Cola(); // Instancia la cola para gestionar los pacientes

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear(); // Limpia la consola en cada vuelta del menú

                Console.WriteLine("=====CLINICA=====");
                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Atender pacientes");
                Console.WriteLine("3. Mostrar pacientes");
                Console.WriteLine("0. Salir");
                Console.Write("Opcion: "); 

                if (int.TryParse(Console.ReadLine(), out opcion)) // Valida que la entrada sea un número
                {
                    switch (opcion)
                    {
                        case 1:
                            Registrar(); // Llama a la función para registrar
                            break;

                        case 2:
                            Atender(); // Llama a la función para atender
                            break;

                        case 3:
                            pacientes.Mostrar(); // Muestra la lista de pacientes en espera
                            Console.WriteLine("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            break;

                        case 0:
                            Console.WriteLine("Saliendo del sistema..."); // Termina el programa
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

            } while (opcion != 0); // El ciclo se repite hasta que se elija 0
        }

        static void Registrar()
        {
            Console.Clear();
            Console.WriteLine("--- Registrar Paciente ---");

            Console.Write("Expediente: ");
            int expediente = int.Parse(Console.ReadLine()); // Lee el número de expediente

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine(); // Lee el nombre del paciente

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine()); // Lee la edad

            Console.Write("Prioridad: ");
            int prioridad = int.Parse(Console.ReadLine()); // Lee la prioridad

            // Crea el objeto paciente con los datos ingresados
            Paciente paciente = new Paciente(expediente, nombre, edad, prioridad);

            pacientes.Encolar(paciente); // Agrega el paciente al final de la cola

            Console.WriteLine("\n¡Paciente registrado con éxito!");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void Atender()
        {
            Console.Clear();
            Console.WriteLine("--- Atender Paciente ---");

            Paciente? paciente = pacientes.Desencolar(); // Saca al primer paciente de la cola

            if (paciente == null)
            {
                Console.WriteLine("No hay pacientes en espera."); // Si la cola está vacía
            }
            else
            {
                Console.WriteLine("Paciente atendido con éxito:");
                Console.WriteLine(paciente); // Muestra los datos del paciente atendido
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}

      