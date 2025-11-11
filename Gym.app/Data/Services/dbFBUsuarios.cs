using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edus.Share.Model;
using Firebase.Database;
using Firebase.Database.Query;


namespace Edus.app.Data.Services
{
    public class dbFBUsuarios
    {
        private string fbUrl = "https://edusprogra5-default-rtdb.europe-west1.firebasedatabase.app/";

        

        public async Task<List<cUsuarioFarmacia>> getUsuariosAsync()
        {
            try
            {
                FirebaseClient fbDb = new FirebaseClient(fbUrl);
                var snapshot = await fbDb.Child("Usuarios").OnceAsync<cUsuarioFarmacia>();
                return snapshot
                    .Where(x => x.Object != null)
                    .Select(x => x.Object)
                    .ToList();
            }
            catch (Exception)
            {
                return new List<cUsuarioFarmacia>();
            }
        }

        //******************************************************************************************************
        public bool agregarUsuario(cUsuarioFarmacia Usuario)
        {
            try
            {
                FirebaseClient fbDb = new FirebaseClient(fbUrl);
                fbDb.Child("Usuarios").PostAsync(Usuario);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
