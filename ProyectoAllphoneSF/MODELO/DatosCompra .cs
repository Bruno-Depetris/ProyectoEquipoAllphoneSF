using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAllphoneSF.MODELO {
    public class DatosCompra {

        public int DatosCompraID {  get; set; }
        public int ClienteID { get; set; }
        public int ProductoID { get; set; }
        public int FormaPagoID { get; set; }
        public DateTime Fecha {  get; set; }
        public int MonedaID { get; set; }
        public int Cantidad {  get; set; }
        public int Cuotas { get; set; }
        public decimal TotalVenta { get; set; }    
    }
}
