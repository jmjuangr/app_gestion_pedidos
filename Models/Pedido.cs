namespace Models;
class Pedido{

public int IdPedido {get;set;}
public DateTime FechaPedido {get;set;}

public Pedido (int idPedido, DateTime fechaPedido){

    IdPedido=idPedido;
    FechaPedido=fechaPedido;
}

public void MostrarDetalles()
        {
            Console.WriteLine($"ID: {IdPedido}, Fecha: {FechaPedido}");
        }
}
