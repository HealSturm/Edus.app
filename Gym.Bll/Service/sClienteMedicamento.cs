using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Edus.Share.Model;
using Edus.Share.Service;
using Edus.Bll.Interface;
using Edus.Bll.Model;


namespace Edus.Bll.Service
{
    public class sClienteMedicamento:IClienteMedicamento
    {
        private string urlApi = "";

        //*********************************************************************************************
        public async Task<List<cClienteMedicamento>> getClienteMedicamento()
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/ClienteMedicamento/getClienteMedicamento";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.GetAsync(urlApi);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<cClienteMedicamento> mLista = await respuesta.Content.ReadFromJsonAsync<List<cClienteMedicamento>>();
                    return mLista;
                }
                else
                {
                    return new List<cClienteMedicamento>();
                }
            }
            catch (Exception ex)
            {
                return new List<cClienteMedicamento>();
            }
        }
        //*********************************************************************************************

        public async Task<bool> insertarClienteMedicamento(cClienteMedicamento pClienteMedicamento)
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/ClienteMedicamento/insertarClienteMedicamento";
                var httpClient = new HttpClient();
                var mclienteSerializado = JsonSerializer.Serialize(pClienteMedicamento);
                HttpContent mContent = new StringContent(mclienteSerializado, Encoding.UTF8, "application/json");
                var respuesta = await httpClient.PostAsync(urlApi, mContent);
                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> actualizarClienteMedicamento(cClienteMedicamento pClienteMedicamento)
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/ClienteMedicamento/actualizarClienteMedicamento";
                var httpClient = new HttpClient();
                var mclienteSerializado = JsonSerializer.Serialize(pClienteMedicamento);
                HttpContent mContent = new StringContent(mclienteSerializado, Encoding.UTF8, "application/json");
                var respuesta = await httpClient.PutAsync(urlApi, mContent);
                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> borrarClienteMedicamento(cClienteMedicamento pClienteMedicamento)
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/ClienteMedicamento/borrarClienteMedicamento";
                var httpClient = new HttpClient();
                var mclienteSerializado = JsonSerializer.Serialize(pClienteMedicamento);
                HttpContent mContent = new StringContent(mclienteSerializado, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(urlApi),
                    Content = mContent
                };
                var respuesta = await httpClient.SendAsync(request);
                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
