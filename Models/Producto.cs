namespace Models;

class Producto {

public int IdProducto {get;set;}
public string NombreProducto {get;set;}

public Producto (int idProducto, string nombreProducto){

    IdProducto=idProducto;
    NombreProducto=nombreProducto;

}

public void MostrarDetalles()
        {
            Console.WriteLine($"ID: {IdProducto}, Nombre: {NombreProducto}");
        }
}