using System;

namespace GestionPedidosTienda
{
    // 1. LISTA ENLAZADA -> Productos
    public class ListaProductos
    {
        private NodoProducto cabeza;

        public void Registrar(Producto p)
        {
            NodoProducto nuevo = new NodoProducto(p);
            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                NodoProducto actual = cabeza;
                while (actual.Siguiente != null)
                    actual = actual.Siguiente;
                actual.Siguiente = nuevo;
            }
        }

        public Producto Buscar(int id)
        {
            NodoProducto actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.ID == id)
                    return actual.Dato;
                actual = actual.Siguiente;
            }
            return null;
        }

        public bool Eliminar(int id)
        {
            if (cabeza == null) return false;

            if (cabeza.Dato.ID == id)
            {
                cabeza = cabeza.Siguiente;
                return true;
            }

            NodoProducto actual = cabeza;
            while (actual.Siguiente != null && actual.Siguiente.Dato.ID != id)
                actual = actual.Siguiente;

            if (actual.Siguiente != null)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                return true;
            }
            return false;
        }

        public void MostrarInventario()
        {
            if (cabeza == null)
            {
                Console.WriteLine("Inventario vacío.");
                return;
            }
            NodoProducto actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine(actual.Dato);
                actual = actual.Siguiente;
            }
        }
    }

    // 2. COLA (FIFO) -> Pedidos pendientes normales
    public class ColaPedidos
    {
        private NodoPedido frente;
        private NodoPedido final;

        public bool EstaVacia() => frente == null;

        public void Encolar(Pedido p)
        {
            NodoPedido nuevo = new NodoPedido(p);
            if (EstaVacia())
            {
                frente = final = nuevo;
            }
            else
            {
                final.Siguiente = nuevo;
                final = nuevo;
            }
        }

        public Pedido Desencolar()
        {
            if (EstaVacia()) return null;
            Pedido p = frente.Dato;
            frente = frente.Siguiente;
            if (frente == null) final = null;
            return p;
        }

        public Pedido CancelarPorNumero(int numero)
        {
            if (EstaVacia()) return null;

            if (frente.Dato.Numero == numero)
            {
                Pedido cancelado = Desencolar();
                cancelado.Estado = "Cancelado";
                return cancelado;
            }

            NodoPedido actual = frente;
            while (actual.Siguiente != null && actual.Siguiente.Dato.Numero != numero)
                actual = actual.Siguiente;

            if (actual.Siguiente != null)
            {
                Pedido cancelado = actual.Siguiente.Dato;
                cancelado.Estado = "Cancelado";
                if (actual.Siguiente == final) final = actual;
                actual.Siguiente = actual.Siguiente.Siguiente;
                return cancelado;
            }
            return null;
        }

        public void Mostrar()
        {
            if (EstaVacia())
            {
                Console.WriteLine("No hay pedidos normales pendientes.");
                return;
            }
            NodoPedido actual = frente;
            while (actual != null)
            {
                Console.WriteLine(actual.Dato);
                actual = actual.Siguiente;
            }
        }

        public void BuscarCliente(string cliente)
        {
            NodoPedido actual = frente;
            bool encontrado = false;
            while (actual != null)
            {
                if (actual.Dato.Cliente.Equals(cliente, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(actual.Dato);
                    encontrado = true;
                }
                actual = actual.Siguiente;
            }
            if (!encontrado) Console.WriteLine("Sin pedidos normales para este cliente.");
        }
    }

    // 3. COLA DE PRIORIDAD -> Pedidos urgentes (Ordenada por prioridad / número)
    public class ColaPrioridadUrgentes
    {
        private NodoPedido frente;

        public bool EstaVacia() => frente == null;

        public void Encolar(Pedido p)
        {
            NodoPedido nuevo = new NodoPedido(p);
            // Inserta ordenado por prioridad (menor número = mayor urgencia)
            if (EstaVacia() || p.Prioridad < frente.Dato.Prioridad)
            {
                nuevo.Siguiente = frente;
                frente = nuevo;
            }
            else
            {
                NodoPedido actual = frente;
                while (actual.Siguiente != null && actual.Siguiente.Dato.Prioridad <= p.Prioridad)
                {
                    actual = actual.Siguiente;
                }
                nuevo.Siguiente = actual.Siguiente;
                actual.Siguiente = nuevo;
            }
        }

        public Pedido AtenderUrgente()
        {
            if (EstaVacia()) return null;
            Pedido p = frente.Dato;
            frente = frente.Siguiente;
            return p;
        }

        public Pedido CancelarPorNumero(int numero)
        {
            if (EstaVacia()) return null;

            if (frente.Dato.Numero == numero)
            {
                Pedido cancelado = AtenderUrgente();
                cancelado.Estado = "Cancelado";
                return cancelado;
            }

            NodoPedido actual = frente;
            while (actual.Siguiente != null && actual.Siguiente.Dato.Numero != numero)
                actual = actual.Siguiente;

            if (actual.Siguiente != null)
            {
                Pedido cancelado = actual.Siguiente.Dato;
                cancelado.Estado = "Cancelado";
                actual.Siguiente = actual.Siguiente.Siguiente;
                return cancelado;
            }
            return null;
        }

        public void Mostrar()
        {
            if (EstaVacia())
            {
                Console.WriteLine("No hay pedidos urgentes pendientes.");
                return;
            }
            NodoPedido actual = frente;
            while (actual != null)
            {
                Console.WriteLine(actual.Dato);
                actual = actual.Siguiente;
            }
        }

        public void BuscarCliente(string cliente)
        {
            NodoPedido actual = frente;
            bool encontrado = false;
            while (actual != null)
            {
                if (actual.Dato.Cliente.Equals(cliente, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(actual.Dato);
                    encontrado = true;
                }
                actual = actual.Siguiente;
            }
            if (!encontrado) Console.WriteLine("Sin pedidos urgentes para este cliente.");
        }
    }

    // 4. PILA (LIFO) -> Historial de operaciones
    public class PilaHistorial
    {
        private NodoHistorial tope;

        public void Push(string operacion)
        {
            string registro = $"[{DateTime.Now:HH:mm:ss}] {operacion}";
            NodoHistorial nuevo = new NodoHistorial(registro);
            nuevo.Siguiente = tope;
            tope = nuevo;
        }

        public void MostrarHistorial()
        {
            if (tope == null)
            {
                Console.WriteLine("El historial está vacío.");
                return;
            }
            NodoHistorial actual = tope;
            while (actual != null)
            {
                Console.WriteLine(actual.Descripcion);
                actual = actual.Siguiente;
            }
        }
    }
}