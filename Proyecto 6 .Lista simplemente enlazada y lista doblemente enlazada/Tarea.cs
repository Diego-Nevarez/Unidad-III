using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto6_Tareas
{

    public class Tarea
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    
    public Tarea(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
            Estado = "pendiente";
        
}
        public override string ToString()
        {
            return $"{Id} - {Descripcion}-{Estado}";

        }
    }
}
