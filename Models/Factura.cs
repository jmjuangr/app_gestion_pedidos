using System.Dynamic;

namespace Models;

class Factura {

public int IdFactura {get;set;}
public double ImporteFactura {get;set;}

public Factura (int idFactura, double importeFactura) {

IdFactura=idFactura;
ImporteFactura=importeFactura;
}
public void MostrarDetalles()
        {
            Console.WriteLine($"ID: {IdFactura}, Importe: {ImporteFactura}");
        }
}

