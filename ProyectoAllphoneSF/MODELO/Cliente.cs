using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAllphoneSF.MODELO {
    public class Cliente {
        public int ClienteID { get; set; } 
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }
        public int ZonaID {  get; set; }   
    }
}
