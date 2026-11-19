using System;

namespace Proyecto3_PilaLlamadas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instanciamos el objeto 'pila' que controlará la estructura de datos tipo Stack
            PilaLlamadas pila = new PilaLlamadas();

            // Variable para almacenar la opción seleccionada por el usuario en el menú
            int opcion;

            // Registramos llamadas iniciales de ejemplo en la pila al arrancar el programa
            pila.RegistrarLlamada("Main");
            pila.RegistrarLlamada("MenuPrincipal");
            pila.RegistrarLlamada("RegistrarCliente");
            pila.RegistrarLlamada("BuscarCliente");

            // Ciclo do-while para mantener el menú interactivo activo hasta que el usuario decida salir (opción 0)
            do
            {
                // Imprimimos la interfaz de usuario en la consola
                Console.WriteLine("\n==========================================");
                Console.WriteLine("    SIMULADOR DE PILA DE LLAMADAS (STACK) ");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Registrar llamada");
                Console.WriteLine("2. Finalizar llamada (Regresar)");
                Console.WriteLine("3. Atender llamada actual");
                Console.WriteLine("4. Mostrar llamadas activas");
                Console.WriteLine("5. Recuperar última llamada");
                Console.WriteLine("6. Buscar llamada");
                Console.WriteLine("7. Eliminar llamada");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                // Validamos que la entrada del usuario sea un número entero válido
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    // Evaluamos la opción elegida mediante una estructura switch
                    switch (opcion)
                    {
                        case 1:
                            // Opción 1: Apilar una nueva llamada
                            Console.Write("\nIngrese el nombre de la función a registrar: ");
                            string? nombreReg = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nombreReg))
                            {
                                pila.RegistrarLlamada(nombreReg);
                            }
                            break;

                        case 2:
                            // Opción 2: Desapilar (pop) la última llamada llamada activa
                            pila.FinalizarLlamada();
                            break;

                        case 3:
                            // Opción 3: Atender o consultar el elemento en la cima (peek) sin eliminarlo
                            pila.AtenderLlamada();
                            break;

                        case 4:
                            // Opción 4: Listar todos los elementos contenidos en la pila
                            pila.MostrarLlamadasActivas();
                            break;

                        case 5:
                            // Opción 5: Recuperar/ver la última llamada registrada
                            pila.RecuperarUltimaLlamada();
                            break;

                        case 6:
                            // Opción 6: Buscar una llamada específica dentro de la estructura
                            Console.Write("\nIngrese el nombre de la función a buscar: ");
                            string? nombreBusc = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nombreBusc))
                            {
                                pila.BuscarLlamada(nombreBusc);
                            }
                            break;

                        case 7:
                            // Opción 7: Eliminar una llamada específica
                            Console.Write("\nIngrese el nombre de la función a eliminar: ");
                            string? nombreEli = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nombreEli))
                            {
                                pila.EliminarLlamada(nombreEli);
                            }
                            break;

                        case 0:
                            // Opción 0: Mensaje de salida del programa
                            Console.WriteLine("\nSaliendo del simulador de pila...");
                            break;

                        default:
                            // Mensaje por si se introduce un número de opción fuera del rango del 0 al 7
                            Console.WriteLine("\nOpción no válida.");
                            break;
                    }
                }
                else
                {
                    // Mensaje de error si el usuario ingresa letras u otros caracteres no numéricos
                    Console.WriteLine("\nPor favor, ingrese un número válido.");
                }

                // Pausa la ejecución y limpia la pantalla antes de volver a mostrar el menú (si no se eligió salir)
                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (opcion != 0);
        }
    }
}