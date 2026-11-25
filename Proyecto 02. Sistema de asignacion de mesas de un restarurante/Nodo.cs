using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2_Restaurante
{
    public class Nodo
    {
        public Cliente Datos;      // Almacena la información del cliente
        public Nodo Siguiente;     // Puntero que apunta al siguiente nodo en la cola

        public Nodo(Cliente cliente)
        {
            Datos = cliente;       // Asigna los datos del cliente al nodo
            Siguiente = null;      // Inicializa el puntero siguiente como nulo al crearlo
        }
    }
}
