using System;
namespace Proyecto1_Clinica
{
    public class Paciente
    {
        public int Expediente { get; set; } // Número de expediente único del paciente
        public string Nombre { get; set; }     // Nombre completo del paciente
        public int Edad { get; set; }         // Edad del paciente
        public int Prioridad { get; set; }     // Nivel de prioridad médica

        public Paciente(int expediente, string nombre, int edad, int prioridad)
        {
            Expediente = expediente; // Asigna el valor del expediente recibido
            Nombre = nombre;         // Asigna el nombre recibido
            Edad = edad;             // Asigna la edad recibida
            Prioridad = prioridad;   // Asigna la prioridad recibida
        }

        public override string ToString()
        {
            // Devuelve una cadena con el formato listo para mostrar en consola
            return $"Expediente: {Expediente} | " +
                   $"Nombre: {Nombre} | " +
                   $"Edad: {Edad} | " +
                   $"prioridad: {Prioridad} | ";
        }
    }
}