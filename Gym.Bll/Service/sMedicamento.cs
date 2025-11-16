using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Edus.Bll.Interface;
using Edus.Bll.Model;
using Edus.Share.Model;
using Edus.Share.Service;

namespace Edus.Bll.Service
{
    public class sMedicamento : IMedicamento
    {
        private string urlApi = "";

        //*********************************************************************************************
        public async Task<List<cMedicamento>> getMedicamento()
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                urlApi = mapi.getWebApiUrl().Trim() + "api/Medicamento/getMedicamento";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.GetAsync(urlApi);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<cMedicamento> mLista = await respuesta.Content.ReadFromJsonAsync<List<cMedicamento>>();
                    return mLista;
                }
                else
                {
                    return new List<cMedicamento>();
                }
            }
            catch (Exception ex)
            {
                return new List<cMedicamento>();
            }
        }

        //*********************************************************************************************
        public async Task<bool> insertarMedicamento(cMedicamento pMedicamento)
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                urlApi = mapi.getWebApiUrl().Trim() + "api/Medicamento/insertarMedicamento";
                var httpClient = new HttpClient();
                var mMedicamentoSerializado = JsonSerializer.Serialize(pMedicamento);
                HttpContent mContent = new StringContent(mMedicamentoSerializado, Encoding.UTF8, "application/json");
                var respuesta = await httpClient.PostAsync(urlApi, mContent);
                return respuesta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //*********************************************************************************************
        public async Task<bool> actualizarMedicamento(cMedicamento pMedicamento)
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                urlApi = mapi.getWebApiUrl().Trim() + "api/Medicamento/actualizarMedicamento";
                var httpClient = new HttpClient();
                var mMedicamentoSerializado = JsonSerializer.Serialize(pMedicamento);
                HttpContent mContent = new StringContent(mMedicamentoSerializado, Encoding.UTF8, "application/json");
                var respuesta = await httpClient.PutAsync(urlApi, mContent);
                return respuesta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //*********************************************************************************************
        public async Task<bool> borrarMedicamento(int IdMedicamento)
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                urlApi = mapi.getWebApiUrl().Trim() + $"api/Medicamento/borrarclienteMedicamento/{IdMedicamento}";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.DeleteAsync(urlApi);
                return respuesta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
