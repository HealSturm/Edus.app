using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edus.Share.Model
{
    public class cUsuarioFarmacia
    {
        public string IdUsuario{ get; set; }
        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Estado { get; set; }

        public string Role { get; set; }

        public cUsuarioFarmacia()
        {
            IdUsuario = string.Empty;
            Nombre = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Estado = string.Empty;
            Role = string.Empty;
        }
    }

}
