using System;

namespace ControlProcesosSO
{
    public enum EstadoProceso
    {
        NUEVO,
        LISTO,
        EJECUTANDO,
        BLOQUEADO,
        TERMINADO
    }

    public class Proceso
    {
        public int PID { get; set; }
        public string Nombre { get; set; }
        public int Prioridad { get; set; }
        public EstadoProceso Estado { get; set; }
        public int TiempoEjecucion { get; set; } // En milisegundos o unidades de tiempo

        public Proceso(int pid, string nombre, int prioridad, int tiempoEjecucion)
        {
            PID = pid;
            Nombre = nombre;
            Prioridad = prioridad;
            Estado = EstadoProceso.NUEVO;
            TiempoEjecucion = tiempoEjecucion;
        }

        public override string ToString()
        {
            return $"[PID: {PID}] {Nombre} | Prioridad: {Prioridad} | Estado: {Estado} | Tiempo: {TiempoEjecucion}s";
        }
    }
}