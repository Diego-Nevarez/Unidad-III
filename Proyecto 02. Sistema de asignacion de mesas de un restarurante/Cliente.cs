//Este proyecto esta directamente relacionado con una de las practicas propuestas por el temario: simular una lista de espera para la asignacion de mesas de un restaunrante
using System;

namespace Proyecto2_Restaurante
{
    public class Cliente
    {
        public string Nombre { get; set; } // Nombre del cliente o familia
        public int Persona { get; set; }     // Número de personas que integran el grupo

        public Cliente(string nombre, int persona)
        {
            Nombre = nombre;     // Asigna el nombre recibido al objeto
            Persona = persona;   // Asigna el número de personas recibido al objeto
        }

        public override string ToString()
        {
            // Devuelve una cadena con el formato personalizado para mostrar en consola
            return $"{Nombre}-{Persona}personas";
        }
    }
}