using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAllphoneSF.MODELO {
    internal class Productos {
        public int ProductoID {  get; set; }  
        public String Nombre { get; set; } 
        public int TipoID {  get; set; }   
        public Decimal PrecioCosto { get; set; }   
        public Decimal PrecioVenta {  get; set; }
        public int Stock {  get; set; }

    }
}
