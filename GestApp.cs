using System;
using System.Collections.Generic;

using Models;

    public class GestApp
    {
        private List<Pedido> pedidos; 
        private List<Factura> facturas; 
        private int contadorPedidos = 1; 
        private int contadorFacturas = 1; 

        public GestApp()
        {
            pedidos = new List<Pedido>(); 
            facturas = new List<Factura>(); 
        }
  
   public void MenuGestApp()
{
    int opcion = 0;

    do
    {
        Console.WriteLine("\n--- Menú Principal ---");
        Console.WriteLine("1. Añadir un pedido");
        Console.WriteLine("2. Añadir factura a un pedido");
        Console.WriteLine("3. Salir");
        Console.WriteLine("Selecciona una opción:");

        
        if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 2)
        {
            Console.WriteLine("Error: Por favor selecciona una opción válida (1-2).");
            continue;
        }

        
        switch (opcion)
        {
            case 1:
                AgregarPedido();
                break;
            case 2:
                AgregarFacturaPedido();
                break;
            case 3:
                Console.WriteLine("Saliendo");
                break;
            default:
                Console.WriteLine("Opción incorrecta");
                break;
        }

    } while (opcion != 3); 
}

private void AgregarPedido()
{
    Console.WriteLine("\n--- Agregar un nuevo pedido ---");

  
    Console.Write("\n--- Introduce Id del pedido ---: ");
    int idPedido = int.Parse(Console.ReadLine());
    Pedido pedido = new Pedido(idPedido);

 
    Console.WriteLine("\n--- Introduce Id del producto ---");
    int idProducto = int.Parse(Console.ReadLine());

    Console.WriteLine("\n--- Introduce el nombre del producto ---");
    string nombreProducto = Console.ReadLine();

    Console.WriteLine("\n--- Introduce el precio del producto ---");
    decimal precioProducto = decimal.Parse(Console.ReadLine());

   
    Producto nuevoProducto = new Producto(idProducto, nombreProducto, precioProducto);
    pedido.AgregarProducto(nuevoProducto);

    
    pedidos.Add(pedido);

    Console.WriteLine("\n--- Detalles del pedido ---");
    pedido.MostrarDetalles();
}

private void AgregarFacturaPedido(){

Console.WriteLine("\n --- Agregar factura a pedido");
Console.Write("\n--- Introduce Id del pedido ---: ");
int idPedidoBuscado = int.Parse(Console.ReadLine());

Pedido pedidoEncontrado = null; 
    foreach (var pedido in pedidos)
    {
        if (pedido.IdPedido == idPedidoBuscado)
        {
            pedidoEncontrado = pedido;
            break;
        }
    }

if (pedidoEncontrado!=null)
    {
      int idFactura =contadorFacturas++;
      Factura nuevaFactura = new Factura(idFactura, pedidoEncontrado.IdPedido, pedidoEncontrado.Productos );
        facturas.Add(nuevaFactura); 

       
        Console.WriteLine("\n--- Factura generada ---");
        nuevaFactura.MostrarDetalles();

    } else
    {
         Console.WriteLine("No existe ese pedido");
    }
}


}
