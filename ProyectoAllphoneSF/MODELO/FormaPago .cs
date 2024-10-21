using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAllphoneSF.MODELO {
    internal class FormaPago {
        public int FormaPagoID { get; set; }
        public string Metodopago { get; set; }
        public decimal TasaInteres { get; set; }
    }
}
