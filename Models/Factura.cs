using System;
using System.Collections.Generic;

namespace Models
{
    public class Factura
    {
       
        public int IdFactura { get; private set; } 
        public int IdPedido { get; private set; } 
        public List<Producto> Productos { get; private set; } 
        public decimal ImporteTotal { get; private set; } 

        
        public Factura(int idFactura, int idPedido, List<Producto> productos)
        {
            IdFactura = idFactura;
            IdPedido = idPedido;
            Productos = productos; 
            ImporteTotal = CalcularImporteTotal(); 
        }

        
        private decimal CalcularImporteTotal()
        {
            decimal total = 0;
            foreach (var producto in Productos)
            {
                
                total += producto.PrecioProducto; 
            }
            return total;
        }

    
        public void MostrarDetalles()
        {
            Console.WriteLine($"Factura N°: {IdFactura}, Pedido N°: {IdPedido}");
            Console.WriteLine("Productos en la factura:");
            foreach (var producto in Productos)
            {
                producto.MostrarDetalles(); 
            }
            Console.WriteLine($"Importe Total: {ImporteTotal:C}"); 
        }
    }
}
