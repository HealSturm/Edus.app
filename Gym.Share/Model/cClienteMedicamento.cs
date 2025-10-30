using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edus.Share.Model
{
    public class cClienteMedicamento
    {
        public int Identificacion { get; set; } 
        public int IdMedicamento { get; set; }
        public string Dosis { get; set; }           // Dosis recomendada

        public cClienteMedicamento()
        {
            Identificacion = 0;
            IdMedicamento = 0;
            Dosis = string.Empty;
        }
    }
}
