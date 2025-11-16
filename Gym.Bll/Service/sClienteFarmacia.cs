using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Edus.Share.Model;
using Edus.Bll.Interface;
using Edus.Bll.Model;

namespace Edus.Bll.Service
{
    public class sClienteFarmacia : IClienteFarmacia
    {
        private readonly HttpClient _http;
        private readonly string _base;
        public sClienteFarmacia(HttpClient http)
        {
            _http = http;
            _base = new cApiUrl().getWebApiUrl() + "api/ClienteFarmacia/";
        }

        public async Task<List<cClienteFarmacia>> getClienteFarmacia()
        {
            try
            {
                var lista = await _http.GetFromJsonAsync<List<cClienteFarmacia>>(_base + "getClienteFarmacia");
                return lista ?? new List<cClienteFarmacia>();
            }
            catch (Exception ex)
            {
                // Propagar o al menos registrar para que no falle silenciosamente.
                throw new Exception("Error llamando a la API ClienteFarmacia: " + ex.Message, ex);
            }
        }

        public async Task<bool> insertarClienteFarmacia(cClienteFarmacia pClienteFarmacia)
        {
            try
            {
                var resp = await _http.PostAsJsonAsync(_base + "insertarClienteFarmacia", pClienteFarmacia);
                return resp.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> actualizarClienteFarmacia(cClienteFarmacia pClienteFarmacia)
        {
            try
            {
                var json = JsonSerializer.Serialize(pClienteFarmacia);
                var resp = await _http.PutAsync(_base + "actualizarClienteFarmacia",
                    new StringContent(json, Encoding.UTF8, "application/json"));
                return resp.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> borrarClienteFarmacia(cClienteFarmacia pClienteFarmacia)
        {
            if (string.IsNullOrWhiteSpace(pClienteFarmacia.Identificacion)) return false;
            try
            {
                var resp = await _http.DeleteAsync(_base + $"borrarClienteFarmacia/{pClienteFarmacia.Identificacion}");
                return resp.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
