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
{
    public class dsClienteMedicamento
    {
        private string sqlConectionString { get; set; }

        public dsClienteMedicamento(string _sqlConectionString)
        {
            this.sqlConectionString = _sqlConectionString;
        }

        protected SqlConnection dbcon()
        {
            return new SqlConnection(sqlConectionString);
        }
        //***************************************************************************

        public async Task<List<cClienteMedicamento>> getClienteMedicamento()
        {
            try
            {
                using var db = dbcon();

                string sql = @"SELECT 
                           Identificacion,
                           IdMedicamento,
                           Dosis
                       FROM ClienteMedicamento";

                var result = await db.QueryAsync<cClienteMedicamento>(sql);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de cliente-medicamento: " + ex.Message);
            }
        }
        //*******************************************************************************************
        public async Task<bool> insertarClienteMedicamento(cClienteMedicamento _ClienteMedicamento)
        {
            try
            {
                using var db = dbcon();

                string sql = @"INSERT INTO ClienteMedicamento
                       (Identificacion, IdMedicamento, Dosis)
                       VALUES
                       (@Identificacion, @IdMedicamento, @Dosis)";

                var result = await db.ExecuteAsync(sql, new
                {
                    _ClienteMedicamento.Identificacion,
                    _ClienteMedicamento.IdMedicamento,
                    _ClienteMedicamento.Dosis
                });

                return result > 0; // True si se insertó correctamente
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el cliente-medicamento: " + ex.Message);
            }
        }
        //*******************************************************************************************
        public async Task<bool> actualizarClienteMedicamento(cClienteMedicamento _ClienteMedicamento)
        {
            try
            {
                using var db = dbcon();

                string sql = @"UPDATE ClienteMedicamento
                       SET Dosis = @Dosis
                       WHERE Identificacion = @Identificacion
                       AND IdMedicamento = @IdMedicamento";

                var result = await db.ExecuteAsync(sql, new
                {
                    _ClienteMedicamento.Dosis,
                    _ClienteMedicamento.Identificacion,
                    _ClienteMedicamento.IdMedicamento
                });

                return result > 0; // True si se actualizó correctamente
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente-medicamento: " + ex.Message);
            }
        }
        //*******************************************************************************************
        public async Task<bool> borrarClienteMedicamento(cClienteMedicamento _ClienteMedicamento)
        {
            try
            {
                using var db = dbcon();

                string sql = @"DELETE FROM ClienteMedicamento
                       WHERE Identificacion = @Identificacion
                       AND IdMedicamento = @IdMedicamento";

                var result = await db.ExecuteAsync(sql, new
                {
                    _ClienteMedicamento.Identificacion,
                    _ClienteMedicamento.IdMedicamento
                });

                return result > 0; // True si se eliminó correctamente
            }
            catch (Exception ex)
            {
                throw new Exception("Error al borrar el cliente-medicamento: " + ex.Message);
            }
        }

    }
}
