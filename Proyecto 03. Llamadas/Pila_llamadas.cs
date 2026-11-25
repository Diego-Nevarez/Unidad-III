using System;

namespace Proyecto3_PilaLlamadas
{
    public class PilaLlamadas
    {
        private Nodo? cima; // Puntero que apunta al elemento superior de la pila

        public PilaLlamadas()
        {
            cima = null; // Inicializa la pila vacía
        }

        public bool EstaVacia()
        {
            return cima == null; // Retorna true si la cima es nula (pila vacía)
        }

        public void RegistrarLlamada(string nombreFuncion)
        {
            Llamada nuevaLlamada = new Llamada(nombreFuncion); // Crea el objeto llamada
            Nodo nuevoNodo = new Nodo(nuevaLlamada);          // Envuelve la llamada en un nodo

            nuevoNodo.Siguiente = cima; // El nuevo nodo apunta a la cima anterior
            cima = nuevoNodo;           // El nuevo nodo se convierte en la nueva cima

            Console.WriteLine($"\n[+] Llamada registrada: Entrando a {nombreFuncion}()");
        }

        public void FinalizarLlamada()
        {
            if (EstaVacia())
            {
                Console.WriteLine("\nLa pila de llamadas está vacía. No hay funciones que finalizar.");
                return;
            }

            Console.WriteLine($"\nRegresando de: {cima!.Dato.NombreFuncion}()");
            cima = cima.Siguiente; // Elimina el elemento de la cima moviendo el puntero al siguiente
        }

        public void AtenderLlamada()
        {
            if (EstaVacia())
            {
                Console.WriteLine("\nNo hay llamadas activas.");
                return;
            }

            Console.Write("\nAtendiendo contexto actual de ejecución en la función: ");
            cima!.Dato.Mostrar(); // Muestra la función que está en la cima
            Console.WriteLine();
        }

        public void MostrarLlamadasActivas()
        {
            if (EstaVacia())
            {
                Console.WriteLine("\nLa pila de llamadas está vacía.");
                return;
            }

            Console.WriteLine("\n--- Pila de llamadas (Call Stack) ---");
            Nodo? actual = cima; // Nodo auxiliar para recorrer desde la cima hacia abajo
            int i = 1;
            while (actual != null)
            {
                Console.Write($"{i}. ");
                actual.Dato.Mostrar(); // Imprime cada llamada activa
                Console.WriteLine();
                actual = actual.Siguiente;
                i++;
            }
        }

        public void RecuperarUltimaLlamada()
        {
            if (EstaVacia())
            {
                Console.WriteLine("\nNo hay llamadas en la pila.");
                return;
            }

            Console.Write("\nÚltima llamada activa (Cima): ");
            cima!.Dato.Mostrar(); // Muestra los datos de la cima sin eliminarla
            Console.WriteLine();
        }

        public void BuscarLlamada(string nombreBuscado)
        {
            if (EstaVacia())
            {
                Console.WriteLine("\nLa pila está vacía.");
                return;
            }

            Nodo? actual = cima;
            int posicion = 1;
            bool encontrado = false;

            while (actual != null)
            {
                // Compara ignorando mayúsculas/minúsculas
                if (actual.Dato.NombreFuncion.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"\n¡Función '{nombreBuscado}' encontrada en la pila (Posición {posicion} desde la cima)!");
                    encontrado = true;
                    break;
                }
                actual = actual.Siguiente;
                posicion++;
            }

            if (!encontrado)
            {
                Console.WriteLine($"\nLa función '{nombreBuscado}' no se encuentra activa en este momento.");
            }
        }

        public void EliminarLlamada(string nombreEliminar)
        {
            if (EstaVacia())
            {
                Console.WriteLine("\nLa pila está vacía.");
                return;
            }

            // Si la función a eliminar está justo en la cima
            if (cima!.Dato.NombreFuncion.Equals(nombreEliminar, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nEliminando y finalizando llamada de la cima: {cima.Dato.NombreFuncion}()");
                cima = cima.Siguiente;
                return;
            }

            // Busca en el resto de la pila para desconectar el nodo deseado
            Nodo? actual = cima;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato.NombreFuncion.Equals(nombreEliminar, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"\nEliminando función '{nombreEliminar}' de la pila de llamadas.");
                    actual.Siguiente = actual.Siguiente.Siguiente; // Salta el nodo para eliminarlo
                    return;
                }
                actual = actual.Siguiente;
            }

            Console.WriteLine($"\nFunción '{nombreEliminar}' no encontrada en la pila.");
        }
    }
}