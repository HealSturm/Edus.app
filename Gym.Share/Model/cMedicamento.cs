using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edus.Share.Model
{
    public class cMedicamento
    {
        public int IdMedicamento { get; set; }          // Consecutivo automático
        public string Descripcion { get; set; }         // Nombre o descripción del medicamento
        public string Presentacion { get; set; }        // Pastilla, jarabe, inyectable, shot, ampollas
        public string Marca { get; set; }               // Marca del medicamento
        public string Indicaciones { get; set; }        // Uso o instrucciones
        public string Estado { get; set; }

        public cMedicamento()
        {
            IdMedicamento = 0;
            Descripcion = string.Empty;
            Presentacion = string.Empty;
            Marca = string.Empty;
            Indicaciones = string.Empty;
            Estado = string.Empty;
        }

    }
}
