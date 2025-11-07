using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edus.Share.Model;


namespace Edus.Bll.Interface
{
    public interface IClienteMedicamento
    {
        Task<List<cClienteMedicamento>> getClienteMedicamento();
        Task<bool> insertarClienteMedicamento(cClienteMedicamento pClienteMedicamento);
        Task<bool> actualizarClienteMedicamento(cClienteMedicamento pClienteMedicamento);
        Task<bool> borrarClienteMedicamento(cClienteMedicamento pClienteMedicamento);
    }
}
