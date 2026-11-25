using System;

namespace ControlProcesosSO
{
    // 1. Lista Enlazada Simple: Almacena el registro maestro de todos los procesos
    public class ListaProcesos
    {
        private NodoProceso cabeza;

        public void Insertar(Proceso p)
        {
            NodoProceso nuevo = new NodoProceso(p);
            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                NodoProceso actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        public Proceso Buscar(int pid)
        {
            NodoProceso actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.PID == pid)
                    return actual.Dato;
                actual = actual.Siguiente;
            }
            return null;
        }

        public bool Eliminar(int pid)
        {
            if (cabeza == null) return false;

            if (cabeza.Dato.PID == pid)
            {
                cabeza = cabeza.Siguiente;
                return true;
            }

            NodoProceso actual = cabeza;
            while (actual.Siguiente != null && actual.Siguiente.Dato.PID != pid)
            {
                actual = actual.Siguiente;
            }

            if (actual.Siguiente != null)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                return true;
            }
            return false;
        }

        public void MostrarTodos()
        {
            if (cabeza == null)
            {
                Console.WriteLine("No hay procesos registrados.");
                return;
            }

            NodoProceso actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine(actual.Dato);
                actual = actual.Siguiente;
            }
        }
    }

    // 2. Cola Lineal (FIFO): Para procesos en espera (LISTOS)
    public class ColaProcesos
    {
        private NodoProceso frente;
        private NodoProceso final;

        public bool EstaVacia() => frente == null;

        public void Encolar(Proceso p)
        {
            p.Estado = EstadoProceso.LISTO;
            NodoProceso nuevo = new NodoProceso(p);
            if (EstaVacia())
            {
                frente = final = nuevo;
            }
            else
            {
                final.Siguiente = nuevo;
                final = nuevo;
            }
        }

        public Proceso Desencolar()
        {
            if (EstaVacia()) return null;

            Proceso p = frente.Dato;
            frente = frente.Siguiente;
            if (frente == null) final = null;
            return p;
        }

        public void EliminarPorPID(int pid)
        {
            if (EstaVacia()) return;

            if (frente.Dato.PID == pid)
            {
                Desencolar();
                return;
            }

            NodoProceso actual = frente;
            while (actual.Siguiente != null && actual.Siguiente.Dato.PID != pid)
            {
                actual = actual.Siguiente;
            }

            if (actual.Siguiente != null)
            {
                if (actual.Siguiente == final) final = actual;
                actual.Siguiente = actual.Siguiente.Siguiente;
            }
        }

        public void MostrarCola()
        {
            if (EstaVacia())
            {
                Console.WriteLine("Cola de procesos listos vacía.");
                return;
            }

            NodoProceso actual = frente;
            while (actual != null)
            {
                Console.Write($"P{actual.Dato.PID:D2} ({actual.Dato.Nombre})");
                if (actual.Siguiente != null) Console.Write(" -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }
    }

    // 3. Cola Circular: Para planificador por turnos (CPU / Round-Robin)
    public class ColaCircularCPU
    {
        private NodoProceso ultimo;

        public bool EstaVacia() => ultimo == null;

        public void Encolar(Proceso p)
        {
            NodoProceso nuevo = new NodoProceso(p);
            if (EstaVacia())
            {
                ultimo = nuevo;
                ultimo.Siguiente = ultimo;
            }
            else
            {
                nuevo.Siguiente = ultimo.Siguiente;
                ultimo.Siguiente = nuevo;
                ultimo = nuevo;
            }
        }

        public Proceso RotarYEjecutar(int quantum)
        {
            if (EstaVacia()) return null;

            NodoProceso frente = ultimo.Siguiente;
            Proceso p = frente.Dato;
            p.Estado = EstadoProceso.EJECUTANDO;
            Console.WriteLine($"Ejecutando {p.Nombre} (PID: {p.PID}) por {quantum}s...");

            p.TiempoEjecucion -= quantum;

            if (p.TiempoEjecucion <= 0)
            {
                p.TiempoEjecucion = 0;
                p.Estado = EstadoProceso.TERMINADO;
                Console.WriteLine($"-> Proceso {p.Nombre} TERMINADO.");

                // Sacar de la cola circular
                if (frente == ultimo)
                    ultimo = null;
                else
                    ultimo.Siguiente = frente.Siguiente;
            }
            else
            {
                p.Estado = EstadoProceso.LISTO;
                // Rotar el puntero 'ultimo' al siguiente nodo
                ultimo = frente;
                Console.WriteLine($"-> Tiempo restante de {p.Nombre}: {p.TiempoEjecucion}s (vuelve a turno).");
            }
            return p;
        }

        public void MostrarColaCircular()
        {
            if (EstaVacia())
            {
                Console.WriteLine("Cola circular de CPU vacía.");
                return;
            }

            NodoProceso actual = ultimo.Siguiente;
            do
            {
                Console.Write($"[P{actual.Dato.PID:D2}: {actual.Dato.TiempoEjecucion}s] -> ");
                actual = actual.Siguiente;
            } while (actual != ultimo.Siguiente);
            Console.WriteLine("(Inicio)");
        }
    }
}