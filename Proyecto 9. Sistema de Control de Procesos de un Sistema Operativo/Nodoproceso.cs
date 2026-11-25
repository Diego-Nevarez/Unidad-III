namespace ControlProcesosSO
{
    public class NodoProceso
    {
        public Proceso Dato { get; set; }
        public NodoProceso Siguiente { get; set; }

        public NodoProceso(Proceso dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}