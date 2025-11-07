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
    public class sClienteFarmacia : IClienteFarmacia
    {
        private string urlApi = "";

        //*********************************************************************************************
        public async Task<List<cClienteFarmacia>> getClienteFarmacia()
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/ClienteFarmacia/getClienteFarmacia";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.GetAsync(urlApi);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<cClienteFarmacia> mLista = await respuesta.Content.ReadFromJsonAsync<List<cClienteFarmacia>>();
                    return mLista;
                }
                else
                {
                    return new List<cClienteFarmacia>();
                }
            }
            catch (Exception ex)
            {
                return new List<cClienteFarmacia>();
            }
        }

        //*********************************************************************************************
        public async Task<bool> insertarClienteFarmacia(cClienteFarmacia pClienteFarmacia)
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/ClienteFarmacia/insertarClienteFarmacia";
                var httpClient = new HttpClient();
                var mclienteSerializado = JsonSerializer.Serialize(pClienteFarmacia);
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
        //*********************************************************************************************
        public async Task<bool> actualizarClienteFarmacia(cClienteFarmacia pClienteFarmacia)
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/ClienteFarmacia/actualizarClienteFarmacia";
                var httpClient = new HttpClient();
                var mclienteSerializado = JsonSerializer.Serialize(pClienteFarmacia);
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
        //*********************************************************************************************
        public async Task<bool> borrarClienteFarmacia(cClienteFarmacia pClienteFarmacia)
        {
            try
            {
                cApiUrl mapi = new cApiUrl();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + $"api/ClienteFarmacia/borrarClienteFarmacia/";

                var httpClient = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(urlApi),
                    Content = new StringContent(
                        JsonSerializer.Serialize(pClienteFarmacia), // ✅ Corregido: era _ClienteFarmacia
                        Encoding.UTF8,
                        "application/json"
                    )
                };

                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Opcional: Log del error
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error al borrar cliente: {errorContent}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Opcional: Log de la excepción
                Console.WriteLine($"Excepción al borrar cliente: {ex.Message}");
                return false;
            }
            
        }
    }
}
