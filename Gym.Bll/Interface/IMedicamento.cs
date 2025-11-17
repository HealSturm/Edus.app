using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edus.Share.Model;

namespace Edus.Bll.Interface
{
    public interface IMedicamento
    {
        Task<bool> actualizarMedicamento(cMedicamento pMedicamento);
        Task<bool> borrarMedicamento(int IdMedicamento);
        Task<List<cMedicamento>> getMedicamento();
        Task<bool> insertarMedicamento(cMedicamento pMedicamento);
    }
}
