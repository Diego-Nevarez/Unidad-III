using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1_Clinica
{
    public class Nodo
    {
        public Paciente Datos;     // Almacena la información (objeto Paciente)
        public Nodo Siguiente;     // Puntero que apunta al siguiente nodo de la cola

        public Nodo(Paciente paciente)
        {
            Datos = paciente;      // Asigna los datos del paciente al nodo
            Siguiente = null;      // Inicializa el puntero siguiente como nulo al crearlo
        }
    }
}