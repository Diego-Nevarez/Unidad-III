using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2_Restaurante
{
    public class Cola
    {
        private Nodo frente; // Apunta al primer cliente en la lista de espera
        private Nodo final;  // Apunta al último cliente que llegó a la lista

        public void Encolar(Cliente cliente)
        {
            Nodo nuevo = new Nodo(cliente); // Crea un nuevo nodo con el cliente

            if (frente == null)
            {
                frente = nuevo; // Si está vacía, el nuevo nodo es el frente...
                final = nuevo;  // ...y también el final
            }
            else
            {
                final.Siguiente = nuevo; // Conecta el último nodo actual con el nuevo
                final = nuevo;           // Actualiza el puntero final al nuevo nodo
            }
        }

        public Cliente Desencolar()
        {
            if (frente == null)
                return null; // Retorna null si la cola está vacía

            Cliente cliente = frente.Datos; // Obtiene los datos del cliente al frente
            frente = frente.Siguiente;       // Avanza el frente al siguiente nodo

            if (frente == null)
                final = null; // Si la cola queda vacía, resetea el final a null

            String.Empty.ToString(); // (Línea de soporte o espacio)
            return cliente;          // Retorna el cliente que fue atendido
        }

        public void Mostrar()
        {
            Nodo actual = frente; // Nodo auxiliar para recorrer la cola desde el frente

            while (actual != null)
            {
                System.Console.WriteLine(actual.Datos); // Muestra los datos del cliente actual
                actual = actual.Siguiente;              // Avanza al siguiente nodo
            }
        }
    }
}