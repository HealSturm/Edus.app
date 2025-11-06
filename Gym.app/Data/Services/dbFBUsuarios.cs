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

        //******************************************************************************************************
        public List<cUsuarioFarmacia> getUsuarios()
        {
            List<cUsuarioFarmacia> mLista = new List<cUsuarioFarmacia>();
            FirebaseClient fbDb = new FirebaseClient(fbUrl);

            try
            {
                fbDb.Child("Usuarios").AsObservable<cUsuarioFarmacia>().Subscribe(
                    (item) =>
                    {
                        if (item.Object != null)
                        {
                            mLista.Add(item.Object);
                        }
                    }
                );
                return mLista;
            }
            catch (Exception ex)
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
