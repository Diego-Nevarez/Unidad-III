using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto5_Navegador
{
    public class Pila
    {
        private Nodo tope; // Apunta a la página actual en la cima de la pila

        private class Nodo
        {
            public string Pagina;      // Almacena el nombre de la página web
            public Nodo Siguiente;     // Puntero que apunta a la página anterior en el historial

            public Nodo(string pagina)
            {
                Pagina = pagina;       // Asigna la página recibida
                Siguiente = null;      // Inicializa el siguiente como nulo
            }
        }

        public void Push(string pagina)
        {
            Nodo nuevo = new Nodo(pagina); // Crea un nuevo nodo con la nueva página visitada
            nuevo.Siguiente = tope;        // El nuevo nodo apunta a la antigua cima
            tope = nuevo;                  // El nuevo nodo se convierte en la nueva cima (página actual)
        }

        public string Pop()
        {
            if (tope == null)              // Si la pila está vacía, retorna null
                return null;

            string pagina = tope.Pagina;   // Guarda la página que está en el tope
            tope = tope.Siguiente;         // Mueve el tope a la página anterior en el historial
            return pagina;                 // Retorna la página extraída
        }
    }
}