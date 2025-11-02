using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edus.Share.Model
{
    public class cClienteFarmacia
    {
        public string Password { get; set; }           // Contraseña del cliente
        public string Role { get; set; }               // Rol (por ejemplo: "Cliente")
        public string Identificacion { get; set; }     // Campo llave (cédula o ID)
        public string Nombre { get; set; }             // Nombre completo del cliente
        public DateTime FechaNacimiento { get; set; }  // Fecha de nacimiento
        public string Telefono { get; set; }           // Número de teléfono
        public string Email { get; set; }              // Correo electrónico
        public string Estado { get; set; }             // Activo / Inactivo 

        public cClienteFarmacia()
        {
            Password = string.Empty;
            Role = string.Empty;
            Identificacion = string.Empty;
            Nombre = string.Empty;
            FechaNacimiento = DateTime.Now;
            Telefono = string.Empty;
            Email = string.Empty;
            Estado = string.Empty;
        }
    }

}
