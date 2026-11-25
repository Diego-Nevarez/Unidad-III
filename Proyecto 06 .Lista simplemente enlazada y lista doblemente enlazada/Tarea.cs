using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto6_Tareas
{
    // Clase que representa una tarea con identificador, descripción y estado
    public class Tarea
    {
        // Identificador único de la tarea
        public int Id { get; set; }
        // Descripción o detalle de la tarea
        public string Descripcion { get; set; }
        // Estado actual de la tarea (por ejemplo, pendiente)
        public string Estado { get; set; }

        // Constructor que inicializa la tarea con su id, descripción y estado inicial "pendiente"
        public Tarea(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
            Estado = "pendiente";
        }

        // Devuelve una representación en texto formateada de la tarea
        public override string ToString()
        {
            return $"{Id} - {Descripcion}-{Estado}";
        }
    }
}
