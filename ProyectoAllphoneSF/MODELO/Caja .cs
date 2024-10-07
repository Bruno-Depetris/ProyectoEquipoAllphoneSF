using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAllphoneSF.MODELO {
    internal class Caja {
        int CajaID { get; set; }
        decimal Montoinicial { get; set; }
        decimal MontoFinal { get; set; }
        DateTime FechaApertura {  get; set; }
        DateTime FechaCierre { get; set; }
    }
}
