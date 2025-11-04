using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edus.Share.Model;

namespace Edus.Bll.Interface
{
    public interface IClienteFarmacia
    {
        Task<List<cClienteFarmacia>> getClienteFarmacia();
        Task<bool> insertarClienteFarmacia(cClienteFarmacia pClienteFarmacia);
    }
}
