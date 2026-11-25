
using System;

namespace GestionPedidosTienda
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaProductos inventario = new ListaProductos();
            ColaPedidos pedidosNormales = new ColaPedidos();
            ColaPrioridadUrgentes pedidosUrgentes = new ColaPrioridadUrgentes();
            PilaHistorial historial = new PilaHistorial();

            int contadorPedidos = 100;
            int totalProcesados = 0;
            int totalCancelados = 0;
            decimal ingresosTotales = 0;

            int opcion;
            do
            {
                Console.WriteLine("\n=== SISTEMA DE GESTIÓN DE PEDIDOS - TIENDA EN LÍNEA ===");
                Console.WriteLine("1. Registrar producto");
                Console.WriteLine("2. Buscar producto");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Registrar pedido");
                Console.WriteLine("5. Cancelar pedido");
                Console.WriteLine("6. Procesar pedido (Normal)");
                Console.WriteLine("7. Atender pedido urgente");
                Console.WriteLine("8. Mostrar pedidos pendientes");
                Console.WriteLine("9. Mostrar historial (Pila)");
                Console.WriteLine("10. Consultar inventario");
                Console.WriteLine("11. Buscar cliente");
                Console.WriteLine("12. Mostrar estadísticas");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = -1;
                Console.WriteLine();

                switch (opcion)
                {
                    case 1: // Registrar producto
                        Console.Write("ID del producto: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nombre: ");
                        string nomProd = Console.ReadLine();
                        Console.Write("Precio: ");
                        decimal precio = decimal.Parse(Console.ReadLine());
                        Console.Write("Existencias: ");
                        int stock = int.Parse(Console.ReadLine());
                        Console.Write("Categoría: ");
                        string cat = Console.ReadLine();

                        Producto prod = new Producto(id, nomProd, precio, stock, cat);
                        inventario.Registrar(prod);
                        historial.Push($"Producto registrado: {nomProd} (ID: {id})");
                        Console.WriteLine("Producto registrado correctamente.");
                        break;

                    case 2: // Buscar producto
                        Console.Write("ID del producto a buscar: ");
                        int idBuscar = int.Parse(Console.ReadLine());
                        Producto pEncontrado = inventario.Buscar(idBuscar);
                        Console.WriteLine(pEncontrado != null ? pEncontrado.ToString() : "Producto no encontrado.");
                        break;

                    case 3: // Eliminar producto
                        Console.Write("ID del producto a eliminar: ");
                        int idElim = int.Parse(Console.ReadLine());
                        if (inventario.Eliminar(idElim))
                        {
                            historial.Push($"Producto eliminado: ID {idElim}");
                            Console.WriteLine("Producto eliminado.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró el producto.");
                        }
                        break;

                    case 4: // Registrar pedido
                        Console.Write("Nombre del cliente: ");
                        string cliente = Console.ReadLine();
                        Console.Write("ID del producto a pedir: ");
                        int idProdPedido = int.Parse(Console.ReadLine());
                        Producto prodSel = inventario.Buscar(idProdPedido);

                        if (prodSel == null)
                        {
                            Console.WriteLine("El producto no existe en el inventario.");
                            break;
                        }

                        Console.Write($"Cantidad (Disponible: {prodSel.Existencias}): ");
                        int cant = int.Parse(Console.ReadLine());

                        if (cant <= 0 || cant > prodSel.Existencias)
                        {
                            Console.WriteLine("Stock insuficiente.");
                            break;
                        }

                        Console.Write("Prioridad (1 = Urgente, 2 = Normal): ");
                        int prio = int.Parse(Console.ReadLine());

                        prodSel.Existencias -= cant;
                        decimal total = prodSel.Precio * cant;
                        string resumen = $"{cant}x {prodSel.Nombre}";

                        Pedido nuevoPedido = new Pedido(++contadorPedidos, cliente, resumen, total, prio);

                        if (prio == 1)
                            pedidosUrgentes.Encolar(nuevoPedido);
                        else
                            pedidosNormales.Encolar(nuevoPedido);

                        historial.Push($"Pedido #{nuevoPedido.Numero} registrado para {cliente} (${total:F2})");
                        Console.WriteLine($"Pedido registrado con éxito: #{nuevoPedido.Numero}");
                        break;

                    case 5: // Cancelar pedido
                        Console.Write("Número de pedido a cancelar: ");
                        int numCancel = int.Parse(Console.ReadLine());
                        Pedido cancelado = pedidosUrgentes.CancelarPorNumero(numCancel) ?? pedidosNormales.CancelarPorNumero(numCancel);

                        if (cancelado != null)
                        {
                            totalCancelados++;
                            historial.Push($"Pedido #{numCancel} CANCELADO.");
                            Console.WriteLine($"Pedido #{numCancel} cancelado.");
                        }
                        else
                        {
                            Console.WriteLine("Pedido no encontrado en pendientes.");
                        }
                        break;

                    case 6: // Procesar pedido normal
                        Pedido procNormal = pedidosNormales.Desencolar();
                        if (procNormal != null)
                        {
                            procNormal.Estado = "Procesado";
                            totalProcesados++;
                            ingresosTotales += procNormal.Total;
                            historial.Push($"Pedido normal #{procNormal.Numero} PROCESADO.");
                            Console.WriteLine($"Procesado: {procNormal}");
                        }
                        else
                        {
                            Console.WriteLine("No hay pedidos normales por procesar.");
                        }
                        break;

                    case 7: // Atender pedido urgente
                        Pedido procUrgente = pedidosUrgentes.AtenderUrgente();
                        if (procUrgente != null)
                        {
                            procUrgente.Estado = "Procesado (Urgente)";
                            totalProcesados++;
                            ingresosTotales += procUrgente.Total;
                            historial.Push($"Pedido URGENTE #{procUrgente.Numero} ATENDIDO.");
                            Console.WriteLine($"Atendido urgente: {procUrgente}");
                        }
                        else
                        {
                            Console.WriteLine("No hay pedidos urgentes pendientes.");
                        }
                        break;

                    case 8: // Mostrar pedidos pendientes
                        Console.WriteLine("--- PEDIDOS URGENTES (Cola de Prioridad) ---");
                        pedidosUrgentes.Mostrar();
                        Console.WriteLine("\n--- PEDIDOS NORMALES (Cola) ---");
                        pedidosNormales.Mostrar();
                        break;

                    case 9: // Mostrar historial
                        Console.WriteLine("--- HISTORIAL DE OPERACIONES (Pila LIFO) ---");
                        historial.MostrarHistorial();
                        break;

                    case 10: // Consultar inventario
                        Console.WriteLine("--- INVENTARIO DE PRODUCTOS (Lista Enlazada) ---");
                        inventario.MostrarInventario();
                        break;

                    case 11: // Buscar cliente
                        Console.Write("Nombre del cliente a buscar: ");
                        string nomCliente = Console.ReadLine();
                        Console.WriteLine("En pedidos urgentes:");
                        pedidosUrgentes.BuscarCliente(nomCliente);
                        Console.WriteLine("En pedidos normales:");
                        pedidosNormales.BuscarCliente(nomCliente);
                        break;

                    case 12: // Mostrar estadísticas
                        Console.WriteLine("--- ESTADÍSTICAS DE LA TIENDA ---");
                        Console.WriteLine($"Pedidos procesados: {totalProcesados}");
                        Console.WriteLine($"Pedidos cancelados: {totalCancelados}");
                        Console.WriteLine($"Ingresos totales generados: ${ingresosTotales:F2}");
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            } while (opcion != 0);
        }
    }
}