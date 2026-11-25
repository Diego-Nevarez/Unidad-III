using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto6_Tareas
{
    // Clase que representa una lista doblemente enlazada para almacenar objetos de tipo Tarea
    public class ListaDoble
    {
        // Referencia al primer nodo de la lista
        private Nodo inicio;

        // Clase interna que representa cada elemento (nodo) de la lista doble
        private class Nodo
        {
            // Almacena los datos de la tarea en este nodo
            public Tarea Datos;
            // Apuntador hacia el nodo anterior en la lista
            public Nodo Anterior;
            // Apuntador hacia el siguiente nodo en la lista
            public Nodo Siguiente;

            // Constructor que inicializa el nodo con una tarea
            public Nodo(Tarea tarea)
            {
                Datos = tarea;
            }
        }

        // Inserta una nueva tarea al final de la lista doble
        public void insertar(Tarea tarea)
        {
            // Crea un nuevo nodo con la tarea recibida
            Nodo nuevo = new Nodo(tarea);

            // Si la lista está vacía, el nuevo nodo pasa a ser el inicio
            if (inicio == null)
            {
                inicio = nuevo;
                return;
            }

            // Recorre la lista desde el inicio hasta encontrar el último nodo
            Nodo actual = inicio;

            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            // Enlaza el último nodo con el nuevo y establece el enlace hacia atrás
            actual.Siguiente = nuevo;
            nuevo.Anterior = actual;
        }

        // Recorre la lista buscando una tarea por su id
        public Tarea Buscar(int id)
        {
            // Comienza el recorrido desde el primer nodo
            Nodo actual = inicio;

            // Avanza nodo por nodo hasta llegar al final de la lista
            while (actual != null)
            {
                actual = actual.Siguiente;
            }

            // Retorna null si no se encuentra o no se devuelve ninguna coincidencia
            return null;
        }

        // Muestra en consola todas las tareas almacenadas en la lista
        public void Mostrar()
        {
            // Comienza desde el primer nodo de la lista
            Nodo actual = inicio;

            // Recorre cada nodo e imprime sus datos
            while (actual != null)
            {
                Console.WriteLine(actual.Datos);
                actual = actual.Siguiente;
            }
        }
    }
}