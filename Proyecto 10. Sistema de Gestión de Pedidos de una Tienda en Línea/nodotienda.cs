namespace GestionPedidosTienda
{
    public class NodoProducto
    {
        public Producto Dato { get; set; }
        public NodoProducto Siguiente { get; set; }

        public NodoProducto(Producto dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    public class NodoPedido
    {
        public Pedido Dato { get; set; }
        public NodoPedido Siguiente { get; set; }

        public NodoPedido(Pedido dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    public class NodoHistorial
    {
        public string Descripcion { get; set; }
        public NodoHistorial Siguiente { get; set; }

        public NodoHistorial(string descripcion)
        {
            Descripcion = descripcion;
            Siguiente = null;
        }
    }
}