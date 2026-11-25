using System;

namespace GestionPedidosTienda
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Existencias { get; set; }
        public string Categoria { get; set; }

        public Producto(int id, string nombre, decimal precio, int existencias, string categoria)
        {
            ID = id;
            Nombre = nombre;
            Precio = precio;
            Existencias = existencias;
            Categoria = categoria;
        }

        public override string ToString()
        {
            return $"ID: {ID} | {Nombre} ({Categoria}) | Precio: ${Precio:F2} | Stock: {Existencias}";
        }
    }

    public class Pedido
    {
        public int Numero { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public string ProductosResumen { get; set; } // Ej. "2x Teclado, 1x Mouse"
        public decimal Total { get; set; }
        public int Prioridad { get; set; } // 1 = Urgente, 2 = Normal
        public string Estado { get; set; } // Pendiente, Procesado, Cancelado

        public Pedido(int numero, string cliente, string productosResumen, decimal total, int prioridad)
        {
            Numero = numero;
            Cliente = cliente;
            Fecha = DateTime.Now;
            ProductosResumen = productosResumen;
            Total = total;
            Prioridad = prioridad;
            Estado = "Pendiente";
        }

        public override string ToString()
        {
            string tipo = Prioridad == 1 ? "URGENTE" : "Normal";
            return $"Pedido #{Numero} | Cliente: {Cliente} | Fecha: {Fecha:dd/MM/yyyy HH:mm} | [{tipo}] | Items: {ProductosResumen} | Total: ${Total:F2} | Estado: {Estado}";
        }
    }
}