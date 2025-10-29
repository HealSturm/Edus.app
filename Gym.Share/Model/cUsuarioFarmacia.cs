using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edus.Share.Model
{
    public class cUsuarioFarmacia
    {
        public int IdUsuario{ get; set; }
        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Estado { get; set; }

        public string Role { get; set; }

        public cUsuarioFarmacia()
        {
            IdUsuario = 0;
            Nombre = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Estado = string.Empty;
            Role = string.Empty;
        }
    }

}
