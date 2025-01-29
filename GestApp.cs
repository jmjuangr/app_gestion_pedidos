using System;
using System.Collections.Generic;
using Models;
using System.Text.Json;
using System.IO;

    public class GestApp
{
    private List<Pedido> pedidos;
    private List<Factura> facturas;
    private int contadorPedidos = 1;
    private int contadorFacturas = 1;
    private const string rutaArchivoPedidos = @"C:\Users\Jose M\Documents\DAW\SAN VALERO\Desarrollo web en entorno servidor\GestApp\data\pedidos.txt"; 
    private const string rutaArchivoProductos = @"C:\Users\Jose M\Documents\DAW\SAN VALERO\Desarrollo web en entorno servidor\GestApp\data\productos.txt";
    private const string rutaArchivoFacturas = @"C:\Users\Jose M\Documents\DAW\SAN VALERO\Desarrollo web en entorno servidor\GestApp\data\facturas.txt";

    public GestApp()
    {
        pedidos = new List<Pedido>();
        facturas = new List<Factura>();
    }

    public void MenuPrincipal()
    {
        int opcion = 0;

        do
        {
            Console.WriteLine("\n--- Menú Principal ---");
            Console.WriteLine("1. Iniciar sesión (Zona privada)");
            Console.WriteLine("2. Acceder a la zona pública");
            Console.WriteLine("3. Salir");
            Console.WriteLine("Selecciona una opción:");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 3)
            {
                Console.WriteLine("Error: Por favor selecciona una opción válida (1-3).");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    ZonaPrivada();
                    break;
                case 2:
                    ZonaPublica();
                    break;
                case 3:
                    Console.WriteLine("Saliendo de la aplicación...");
                    break;
            }
        } while (opcion != 3);
    }

    private void ZonaPrivada()
    {
        Console.WriteLine("\n--- Zona Privada ---");
        Console.Write("Introduce la contraseña: ");
        string password = Console.ReadLine();

        if (password == "1234") // Contraseña fija
        {
            Console.WriteLine("Acceso concedido.");
            MenuZonaPrivada();
        }
        else
        {
            Console.WriteLine("Acceso denegado. Contraseña incorrecta.");
        }
    }

    private void MenuZonaPrivada()
    {
        int opcion = 0;

        do
        {
            Console.WriteLine("\n--- Menú Zona Privada ---");
            Console.WriteLine("1. Gestionar pedidos");
            Console.WriteLine("2. Gestionar facturas");
            Console.WriteLine("3. Volver al menú principal");
            Console.WriteLine("Selecciona una opción:");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 3)
            {
                Console.WriteLine("Error: Por favor selecciona una opción válida (1-3).");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    MenuGestionPedidos();
                    break;
                case 2:
                   MenuGestionFacturas();
                    break;
                case 3:
                    Console.WriteLine("Saliendo de la zona privada...");
                    break;
            }
        } while (opcion != 3);
    }

    private void ZonaPublica()
    {
        Console.WriteLine("\n--- Zona Pública ---");
        Console.WriteLine("1. Mostrar productos disponibles");
        Console.WriteLine("2. Volver al menú principal");
        Console.WriteLine("Selecciona una opción:");

        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                MostrarProductosPublicos();
                break;
            case 2:
               Console.WriteLine("Volviendo al menú principal...");
                break;
        }
    }

    private void MostrarProductosPublicos()
    {
        Console.WriteLine("\n--- Productos Disponibles ---");
        

        if (File.Exists(rutaArchivoProductos))
        {
            using (StreamReader sr = new StreamReader(rutaArchivoProductos))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] datos = linea.Split('|');
                    int idProducto = int.Parse(datos[0]);
                    string nombreProducto = datos[1];
                    decimal precioProducto = decimal.Parse(datos[2]);
                    Console.WriteLine($"\tProducto ID: {idProducto}, Nombre: {nombreProducto}, Precio: {precioProducto:C}");
                }
            }
        }
        else
        {
            Console.WriteLine("No se encontró el archivo de pedidos.");
        
    }
      
    }

    private void MenuGestionFacturas(){

        int opcion=0;

        do{
            Console.WriteLine("\n--- Gestión de Facturas ---");
            Console.WriteLine("1. Agregar una factura a un pedido");
            Console.WriteLine("2. Volver al menú anterior");
       if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 2)
            {
                Console.WriteLine("Error: Por favor selecciona una opción válida (1-2).");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    AgregarFacturaPedido();
                    break;
                case 2:
                   Console.WriteLine("Volviendo al menú anterior...");
                    break;
            }
        } while (opcion != 2);

    }

   private void AgregarFacturaPedido()
{
    Console.WriteLine("\n--- Agregar una factura a un pedido ---");

    Console.Write("\n--- Introduce Id del pedido ---: ");
    int idPedido = int.Parse(Console.ReadLine());

    Console.Write("\n--- Introduce Id de la factura ---: ");
    int idFactura = int.Parse(Console.ReadLine());

    Console.Write("\n--- Introduce el número de productos en la factura ---: ");
    int cantidadProductos = int.Parse(Console.ReadLine());

    List<Producto> productos = new List<Producto>();

    for (int i = 0; i < cantidadProductos; i++)
    {
        Console.Write($"\n--- Introduce Id del producto {i + 1} ---: ");
        int idProducto = int.Parse(Console.ReadLine());

        Console.Write($"--- Introduce el nombre del producto {i + 1} ---: ");
        string nombreProducto = Console.ReadLine();

        Console.Write($"--- Introduce el precio del producto {i + 1} ---: ");
        decimal precioProducto = decimal.Parse(Console.ReadLine());

        productos.Add(new Producto(idProducto, nombreProducto, precioProducto));
    }

    Factura nuevaFactura = new Factura(idFactura, idPedido, productos);
    facturas.Add(nuevaFactura);

    Console.WriteLine("\n--- Detalles de la factura ---");
    nuevaFactura.MostrarDetalles();
    nuevaFactura.GuardarFactura(rutaArchivoFacturas);
}

    private void MenuGestionPedidos()
    {
        int opcion = 0;

        do
        {
            Console.WriteLine("\n--- Gestión de Pedidos ---");
            Console.WriteLine("1. Agregar un pedido");
            Console.WriteLine("2. Buscar un pedido");
            Console.WriteLine("3. Mostrar todos los pedidos");
            Console.WriteLine("4. Volver al menú anterior");
            Console.WriteLine("Selecciona una opción:");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
            {
                Console.WriteLine("Error: Por favor selecciona una opción válida (1-4).");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    AgregarPedido();
                    break;
                case 2:
                    BuscarPedido();
                    break;
                case 3:
                    MostrarTodosLosPedidos();
                    break;
                case 4:
                    Console.WriteLine("Volviendo al menú anterior...");
                    break;
            }
        } while (opcion != 4);
    }

    private void MostrarTodosLosPedidos()
    {
        Console.WriteLine("\n--- Todos los Pedidos ---");

        if (File.Exists(rutaArchivoPedidos))
        {
            using (StreamReader sr = new StreamReader(rutaArchivoPedidos))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] datos = linea.Split('|');
                    int idPedido = int.Parse(datos[0]);
                    int idProducto = int.Parse(datos[1]);
                    string nombreProducto = datos[2];
                    decimal precioProducto = decimal.Parse(datos[3]);

                    Console.WriteLine($"Pedido N°: {idPedido}");
                    Console.WriteLine($"\tProducto ID: {idProducto}, Nombre: {nombreProducto}, Precio: {precioProducto:C}");
                }
            }
        }
        else
        {
            Console.WriteLine("No se encontró el archivo de pedidos.");
        }
    }

    private void AgregarPedido()
    {
        Console.WriteLine("\n--- Agregar un nuevo pedido ---");

        Console.Write("\n--- Introduce Id del pedido ---: ");
        int idPedido = int.Parse(Console.ReadLine());
        Pedido pedido = new Pedido(idPedido);

        Console.Write("\n--- Introduce Id del producto ---");
        int idProducto = int.Parse(Console.ReadLine());

        Console.Write("\n--- Introduce el nombre del producto ---");
        string nombreProducto = Console.ReadLine();

        Console.Write("\n--- Introduce el precio del producto ---");
        decimal precioProducto = decimal.Parse(Console.ReadLine());

        Producto nuevoProducto = new Producto(idProducto, nombreProducto, precioProducto);
        pedido.AgregarProducto(nuevoProducto);

        pedidos.Add(pedido);

        Console.WriteLine("\n--- Detalles del pedido ---");
        pedido.MostrarDetalles();

        pedido.GuardarPedido(rutaArchivoPedidos);
    }

    private void BuscarPedido()
    {
        Console.Write("\n--- Buscar pedido ---: ");
        Console.Write("\n--- Introduce Id del pedido ---: ");
        int idPedidoBuscado = int.Parse(Console.ReadLine());

        try
        {
            if (File.Exists(rutaArchivoPedidos))
            {
                using (StreamReader sr = new StreamReader(rutaArchivoPedidos))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] datos = linea.Split('|');
                        int idPedido = int.Parse(datos[0]);

                        if (idPedido == idPedidoBuscado)
                        {
                            int idProducto = int.Parse(datos[1]);
                            string nombreProducto = datos[2];
                            decimal precioProducto = decimal.Parse(datos[3]);

                            Producto producto = new Producto(idProducto, nombreProducto, precioProducto);
                            Pedido pedido = new Pedido(idPedido);
                            pedido.AgregarProducto(producto);

                            Console.WriteLine("\n--- Pedido encontrado ---");
                            pedido.MostrarDetalles();
                            return;
                        }
                    }
                }

                Console.WriteLine("No existe ningún pedido con ese ID.");
            }
            else
            {
                Console.WriteLine("No se encontró el archivo de pedidos.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al buscar el pedido: {ex.Message}");
        }
    }
}
