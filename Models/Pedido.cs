namespace Models;
class Pedido

{
   

        public int IdPedido { get; private set; } 
        public DateTime Fecha { get; private set; } 
        public List<Producto> Productos { get; private set; } 

        
        public Pedido(int idPedido)
        {
            IdPedido = idPedido;
            Fecha = DateTime.Now; 
            Productos = new List<Producto>(); 
        }


        public void AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
        }

         public void MostrarDetalles()
        {
            Console.WriteLine($"Pedido N°: {IdPedido}, Fecha: {Fecha}");
            Console.WriteLine("Productos en el pedido:");

            if (Productos.Count == 0)
            {
                Console.WriteLine("No hay productos en este pedido.");
            }
            else
            {
                foreach (var producto in Productos)
                {
                    producto.MostrarDetalles();
                }
            }
        }



    public void GuardarPedido(string filePath)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (var producto in Productos)
            {
                sw.WriteLine($"{producto.GetType().Name}|{producto.IdProducto}|{producto.NombreProducto}|{producto.PrecioProducto}");
            }
        }

        Console.WriteLine($"Pedido guardado correctamente en {filePath}.");
    }

    public void CargarPedido(string filePath)
    {
        if (File.Exists(filePath))
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] datos = linea.Split('|');
                    int idProducto = int.Parse(datos[0]);
                    string nombre = datos[1];
                    decimal precio = decimal.Parse(datos[2]);
                }
            }

            Console.WriteLine("Pedido cargado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró el archivo.");
        }
    }
    }


