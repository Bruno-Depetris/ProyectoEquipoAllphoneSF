using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProductoConTipo {
    public int ProductoID { get; set; }
    public string Nombre { get; set; }
    public int TipoID { get; set; }
    public string NombreTipo { get; set; }  // Esto viene de TiposProductos
    public decimal PrecioCosto { get; set; }
    public decimal PrecioVenta { get; set; }
    public int Stock { get; set; }
}
