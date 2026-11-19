using Proyecto1_Clinica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1_Clinica
{
    internal class Cola
    {
        private Nodo? Frente; // Apunta al primer elemento de la cola
        private Nodo? final;  // Apunta al último elemento de la cola

        public Cola()
        {
            Frente = null; // Inicializa la cola vacía
            final = null;  // Inicializa la cola vacía
        }

        public void Encolar(Paciente paciente)
        {
            Nodo nuevo = new Nodo(paciente); // Crea el nuevo nodo con el paciente
            if (Frente == null)
            {
                Frente = nuevo; // Si está vacía, el nuevo nodo es el frente
                final = nuevo;  // y también el final
            }
            else
            {
                final.Siguiente = nuevo; // Conecta el último nodo actual con el nuevo
                final = nuevo;           // Actualiza el puntero final
            }
        }

        public Paciente? Desencolar()
        {
            if (Frente == null)
            {
                return null; // Retorna null si la cola está vacía
            }

            Paciente paciente = Frente.Datos; // Obtiene los datos del paciente al frente

            Frente = Frente.Siguiente; // Avanza el frente al siguiente nodo

            if (Frente == null)
            {
                final = null; // Si la cola queda vacía, resetea el final a null
            }

            return paciente; // Retorna el paciente atendido
        }

        public void Mostrar()
        {
            if (Frente == null)
            {
                Console.WriteLine("No hay pacientes registrados");
                return; // Sale si no hay elementos
            }

            Nodo? aux = Frente; // Nodo auxiliar para recorrer la cola desde el frente
            while (aux != null)
            {
                Console.WriteLine(aux.Datos); // Muestra los datos del nodo actual
                aux = aux.Siguiente;          // Avanza al siguiente nodo
            }
        }
    }
}


