using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Edus.Share.Model;

namespace Edus.Share.Service
{ //*******************************************************************************
    public class dsClienteFarmacia
    {
        private string sqlConectionString { get; set; }

        public dsClienteFarmacia(string _sqlConectionString)
        {
            this.sqlConectionString = _sqlConectionString;
        }

        protected SqlConnection dbcon()
        {
            return new SqlConnection(sqlConectionString);
        }

        //*******************************************************************************

        public async Task<List<cClienteFarmacia>> getClienteFarmacia()
        {
            try
            {
                using var db = dbcon();

                string sql = @"SELECT 
                           Password,
                           Role,
                           Identificacion,
                           Nombre,
                           FechaNacimiento,
                           Telefono,
                           Email,
                           Estado
                       FROM ClienteFarmacia";

                var result = await db.QueryAsync<cClienteFarmacia>(sql);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de clientes de farmacia: " + ex.Message);
            }
        }
        //**********************************************************************************************
        public async Task<bool> insertarClienteFarmacia(cClienteFarmacia _ClienteFarmacia)
        {
            try
            {
                using var db = dbcon();

                string sql = @"INSERT INTO cClienteFarmacia
                       (Password, Role, Identificacion, Nombre, FechaNacimiento, Telefono, Email, Estado)
                       VALUES
                       (@Password, @Role, @Identificacion, @Nombre, @FechaNacimiento, @Telefono, @Email, @Estado)";

                var result = await db.ExecuteAsync(sql, new
                {
                    _ClienteFarmacia.Password,
                    _ClienteFarmacia.Role,
                    _ClienteFarmacia.Identificacion,
                    _ClienteFarmacia.Nombre,
                    _ClienteFarmacia.FechaNacimiento,
                    _ClienteFarmacia.Telefono,
                    _ClienteFarmacia.Email,
                    _ClienteFarmacia.Estado
                });

                return result > 0; // true si se insertó al menos un registro
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el cliente en la farmacia: " + ex.Message);
            }
        }

        //**************************************************************************************************
        public async Task<bool> actualizarClienteFarmacia(cClienteFarmacia _ClienteFarmacia)
        {
            try
            {
                using var db = dbcon();

                string sql = @"UPDATE cClienteFarmacia
                       SET 
                           Password = @Password,
                           Role = @Role,
                           Nombre = @Nombre,
                           FechaNacimiento = @FechaNacimiento,
                           Telefono = @Telefono,
                           Email = @Email,
                           Estado = @Estado
                       WHERE Identificacion = @Identificacion";

                var result = await db.ExecuteAsync(sql, new
                {
                    _ClienteFarmacia.Password,
                    _ClienteFarmacia.Role,
                    _ClienteFarmacia.Nombre,
                    _ClienteFarmacia.FechaNacimiento,
                    _ClienteFarmacia.Telefono,
                    _ClienteFarmacia.Email,
                    _ClienteFarmacia.Estado,
                    _ClienteFarmacia.Identificacion
                });

                return result > 0; // True si se actualizó al menos una fila
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente de farmacia: " + ex.Message);
            }
        }
        //********************************************************************************************

        public async Task<bool> borrarClienteFarmacia(cClienteFarmacia _ClienteFarmacia)
        {
            try
            {
                using var db = dbcon();

                string sql = @"DELETE FROM cClienteFarmacia
                       WHERE Identificacion = @Identificacion";

                var result = await db.ExecuteAsync(sql, new
                {
                    _ClienteFarmacia.Identificacion
                });

                return result > 0; // True si se eliminó al menos un registro
            }
            catch (Exception ex)
            {
                throw new Exception("Error al borrar el cliente de farmacia: " + ex.Message);
            }
        }

    }
}