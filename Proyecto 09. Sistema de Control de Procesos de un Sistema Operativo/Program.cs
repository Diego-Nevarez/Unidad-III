using System;

namespace ControlProcesosSO
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaProcesos listaMaestra = new ListaProcesos();
            ColaProcesos colaListos = new ColaProcesos();
            ColaCircularCPU cpuCircular = new ColaCircularCPU();

            int contadorPID = 1;
            int opcion;

            do
            {
                Console.WriteLine("\n=== SISTEMA DE CONTROL DE PROCESOS (SO) ===");
                Console.WriteLine("1. Crear proceso");
                Console.WriteLine("2. Eliminar proceso");
                Console.WriteLine("3. Ejecutar proceso (Pasar de Cola Listos a Ejecución / CPU)");
                Console.WriteLine("4. Bloquear proceso");
                Console.WriteLine("5. Desbloquear proceso");
                Console.WriteLine("6. Mostrar todos los procesos");
                Console.WriteLine("7. Buscar proceso por PID");
                Console.WriteLine("8. Administrar cola de procesos (Ver Cola / Ejecutar turno Circular)");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = -1;
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nombre del proceso: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Prioridad (1-Alta, 2-Media, 3-Baja): ");
                        int prioridad = int.Parse(Console.ReadLine());
                        Console.Write("Tiempo de ejecución (segundos): ");
                        int tiempo = int.Parse(Console.ReadLine());

                        Proceso nuevo = new Proceso(contadorPID++, nombre, prioridad, tiempo);
                        listaMaestra.Insertar(nuevo);
                        colaListos.Encolar(nuevo); // Pasa a LISTO
                        Console.WriteLine($"Proceso creado y encolado: {nuevo}");
                        break;

                    case 2:
                        Console.Write("Ingrese el PID del proceso a eliminar: ");
                        int pidEliminar = int.Parse(Console.ReadLine());
                        colaListos.EliminarPorPID(pidEliminar);
                        if (listaMaestra.Eliminar(pidEliminar))
                            Console.WriteLine("Proceso eliminado del sistema.");
                        else
                            Console.WriteLine("PID no encontrado.");
                        break;

                    case 3:
                        Proceso aEjecutar = colaListos.Desencolar();
                        if (aEjecutar != null)
                        {
                            aEjecutar.Estado = EstadoProceso.EJECUTANDO;
                            cpuCircular.Encolar(aEjecutar);
                            Console.WriteLine($"Proceso movido a CPU Circular: {aEjecutar}");
                        }
                        else
                        {
                            Console.WriteLine("No hay procesos en la cola de listos.");
                        }
                        break;

                    case 4:
                        Console.Write("Ingrese PID del proceso a bloquear: ");
                        int pidBloquear = int.Parse(Console.ReadLine());
                        Proceso pBloq = listaMaestra.Buscar(pidBloquear);
                        if (pBloq != null && pBloq.Estado != EstadoProceso.TERMINADO)
                        {
                            pBloq.Estado = EstadoProceso.BLOQUEADO;
                            colaListos.EliminarPorPID(pidBloquear);
                            Console.WriteLine($"Proceso {pBloq.Nombre} ha sido BLOQUEADO.");
                        }
                        else
                        {
                            Console.WriteLine("Proceso no válido o ya terminado.");
                        }
                        break;

                    case 5:
                        Console.Write("Ingrese PID del proceso a desbloquear: ");
                        int pidDesbloq = int.Parse(Console.ReadLine());
                        Proceso pDesbloq = listaMaestra.Buscar(pidDesbloq);
                        if (pDesbloq != null && pDesbloq.Estado == EstadoProceso.BLOQUEADO)
                        {
                            colaListos.Encolar(pDesbloq);
                            Console.WriteLine($"Proceso {pDesbloq.Nombre} desbloqueado y devuelto a LISTO.");
                        }
                        else
                        {
                            Console.WriteLine("El proceso no existe o no está bloqueado.");
                        }
                        break;

                    case 6:
                        Console.WriteLine("--- LISTA MAESTRA DE PROCESOS ---");
                        listaMaestra.MostrarTodos();
                        break;

                    case 7:
                        Console.Write("Ingrese PID a buscar: ");
                        int pidBuscar = int.Parse(Console.ReadLine());
                        Proceso encontrado = listaMaestra.Buscar(pidBuscar);
                        Console.WriteLine(encontrado != null ? encontrado.ToString() : "Proceso no encontrado.");
                        break;

                    case 8:
                        Console.WriteLine("--- COLA DE PROCESOS LISTOS ---");
                        colaListos.MostrarCola();
                        Console.WriteLine("\n--- COLA CIRCULAR DE CPU ---");
                        cpuCircular.MostrarColaCircular();
                        Console.Write("\n¿Desea ejecutar un ciclo de CPU (Quantum = 2s)? (s/n): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            cpuCircular.RotarYEjecutar(2);
                        }
                        break;

                    case 0:
                        Console.WriteLine("Cerrando simulador...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 0);
        }
    }
}