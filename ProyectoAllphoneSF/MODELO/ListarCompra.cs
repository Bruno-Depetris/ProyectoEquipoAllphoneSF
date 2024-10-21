using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAllphoneSF.MODELO {
    internal class ListarCompra {
        public int DatosCompraID { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreCliente { get; set; } 
        public string ApellidoCliente { get; set; } 
        public string Direccion { get; set; } 
        public string Email { get; set; } 
        public string Producto { get; set; } 
        public string FormaPago { get; set; } 
        public string Moneda { get; set; } 
        public decimal PrecioVenta {  get; set; }
        public int Cuotas {  get; set; }
        public decimal TasaInteres { get; set; }
        public int Cantidad { get; set; }
        public decimal TotalVenta { get; set; }
    }
}
