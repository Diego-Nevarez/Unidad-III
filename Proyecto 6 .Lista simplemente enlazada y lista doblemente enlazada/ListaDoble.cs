using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto6_Tareas

{
    public class ListaDoble
    {
        private Nodo inicio;

        private class Nodo
        {
            public Tarea Datos;
            public Nodo Anterior;
            public Nodo Siguiente;

            public Nodo(Tarea tarea)
            {
                Datos = tarea;
            }
        }
        public void insertar(Tarea tarea) {
            Nodo nuevo = new Nodo(tarea);

            if (inicio == null)
            {
                inicio = nuevo;
                return;
            }
            Nodo actual = inicio;

            while (actual.Siguiente != null) {
                actual = actual.Siguiente;

                actual.Siguiente = nuevo;
                nuevo.Anterior = actual;
            }


            public Tarea Buscar(int id)
        {
            Nodo actual = inicio;

            while (actual != null) {

                actual = actual.Siguiente;
            }
            return null;

        }
        public void Mostrar()
        {
            Nodo actual = inicio;

            while (actual != null)
            {
                Console.WriteLine(actual.Datos);
                actual = actual.Siguiente;
            }
        }
    }
}
