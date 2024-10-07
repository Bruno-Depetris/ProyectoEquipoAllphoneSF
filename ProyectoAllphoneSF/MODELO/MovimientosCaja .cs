using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAllphoneSF.MODELO {
    internal class MovimientosCaja {
        int  Movimiento { get; set; }
        int CajaID { get; set; }
        decimal Monto { get; set; }
        string TipoMovimiento { get; set; }
        string Descripcion { get; set; }
        DateTime Fecha { get; set; }
    }
}
