using ProyectoAllphoneSF.MODELO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAllphoneSF.LOGICA {
    internal class LogicaZona {

        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        private static LogicaZona _LogicaZona;

        public LogicaZona() {

        }

        public static LogicaZona Instancia {
            get {
                if (_LogicaZona == null) {
                    _LogicaZona = new LogicaZona();

                }
                return _LogicaZona;
            }
        }




    }
}
