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
    public class dsMedicamento
    {
        private string sqlConectionString { get; set; }

        public dsMedicamento(string _sqlConectionString)
        {
            this.sqlConectionString = _sqlConectionString;
        }

        protected SqlConnection dbcon()
        {
            return new SqlConnection(sqlConectionString);
        }
        //***************************************************************************

        public async Task<List<cMedicamento>> getMedicamento()
        {
            try
            {
                using var db = dbcon();

                string sql = @"SELECT 
                           IdMedicamento,
                           Descripcion,
                           Presentacion,
                           Marca,
                           Indicaciones,
                           Estado
                       FROM Medicamento";

                var result = await db.QueryAsync<cMedicamento>(sql);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de medicamentos: " + ex.Message);
            }
        }
        //*******************************************************************************************

        public async Task<bool> insertarMedicamento(cMedicamento _Medicamento)
        {
            try
            {
                using var db = dbcon();

                string sql = @"INSERT INTO Medicamento
                       (Descripcion, Presentacion, Marca, Indicaciones, Estado)
                       VALUES
                       (@Descripcion, @Presentacion, @Marca, @Indicaciones, @Estado)";

                var result = await db.ExecuteAsync(sql, new
                {
                    _Medicamento.Descripcion,
                    _Medicamento.Presentacion,
                    _Medicamento.Marca,
                    _Medicamento.Indicaciones,
                    _Medicamento.Estado
                });

                return result > 0; // True si se insertó correctamente
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el medicamento: " + ex.Message);
            }
        }
        //*******************************************************************************************

        public async Task<bool> actualizarMedicamento(cMedicamento _Medicamento)
        {
            try
            {
                using var db = dbcon();

                string sql = @"UPDATE Medicamento
                       SET 
                           Descripcion = @Descripcion,
                           Presentacion = @Presentacion,
                           Marca = @Marca,
                           Indicaciones = @Indicaciones,
                           Estado = @Estado
                       WHERE IdMedicamento = @IdMedicamento";

                var result = await db.ExecuteAsync(sql, new
                {
                    _Medicamento.Descripcion,
                    _Medicamento.Presentacion,
                    _Medicamento.Marca,
                    _Medicamento.Indicaciones,
                    _Medicamento.Estado,
                    _Medicamento.IdMedicamento
                });

                return result > 0; // True si se actualizó correctamente
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el medicamento: " + ex.Message);
            }
        }

        //*******************************************************************************************

        public async Task<bool> borrarMedicamento(cMedicamento _Medicamento)
        {
            try
            {
                using var db = dbcon();

                string sql = @"DELETE FROM Medicamento
                       WHERE IdMedicamento = @IdMedicamento";

                var result = await db.ExecuteAsync(sql, new
                {
                    _Medicamento.IdMedicamento
                });

                return result > 0; // True si se eliminó correctamente
            }
            catch (Exception ex)
            {
                throw new Exception("Error al borrar el medicamento: " + ex.Message);
            }
        }

    }
}
