using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAllphoneSF.MODELO
{
    internal class Cliente_Con_Venta
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int ZonaID { get; set; }
        public string Localidad { get; set; }
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public int TipoID { get; set; }
        public string NombreTipo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int FormaPagoID { get; set; }
        public string Metodopago { get; set; }
        public decimal Descuento { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public decimal TotalVenta { get; set; }

    }
}
