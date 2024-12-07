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
        Console.WriteLine("1. Añadir un Pedido");
        Console.WriteLine("2. Salir");
        Console.WriteLine("Selecciona una opción:");

        
        if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 2)
        {
            Console.WriteLine("Error: Por favor selecciona una opción válida (1-2).");
            continue;
        }

        
        switch (opcion)
        {
            case 1:
                //AgregarPedido();
                break;
            case 2:
                Console.WriteLine("Saliendo");
                break;
            default:
                Console.WriteLine("Opción incorrecta");
                break;
        }

    } while (opcion != 2); 
}



    }
