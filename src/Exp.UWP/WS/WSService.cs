using Exp.Domain.Core.Models;
using Exp.Infra.Identity.ViewModels;
using Exp.UWP.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Exp.UWP.WS
{
    public class WSService : IWSService
    {
        public async Task<object> Delete(string uri, Guid id)
        {
            try
            {
                string uriCompleta = $"{uri}/{id}";
                HttpClient client = new HttpClient();
                var result = await client.DeleteAsync(uriCompleta);
                string content = await result.Content.ReadAsStringAsync();
                var response = await GetResponse<bool>(result);
                return response;
            }
            catch (Exception e)
            {
                return new Response(e.Message, false);
            }
        }


        public async Task<object> Get<T>(string uri)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.GetAsync(uri);
                var response = await GetResponse<T>(result);
                return response;
            }
            catch (Exception e)
            {
                return new Response(e.Message, false);
            }
        }

        public async Task<object> Login(LoginViewModel loginViewModel)
        {
            try
            {
                string uri = Constantes.SERVER_LOGIN;
                HttpClient client = new HttpClient();
                string objSerialize = JsonConvert.SerializeObject(loginViewModel);
                StringContent stringContent = new StringContent(objSerialize, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(uri, stringContent);

                var response = await GetResponse<TokenContainer>(result);
                return response;
            }
            catch (Exception e)
            {
                return new Response(e.Message, false);
            }
        }

        public async Task<object> Post<T>(string uri, T obj)
        {
            try
            {
                if (obj == null) return new Response("Objeto Nulo", false);
                HttpClient client = new HttpClient();
                string objSerialize = JsonConvert.SerializeObject(obj);
                StringContent stringContent = new StringContent(objSerialize, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(uri, stringContent);
                var response = await GetResponse<T>(result);
                return response;
            }
            catch (Exception e)
            {
                return new Response(e.Message, false);
            }
        }

        public async Task<object> Put<T>(string uri, T obj)
        {
            try
            {
                if (obj == null) return new Response("Objeto Nulo", false);
                HttpClient client = new HttpClient();
                string objSerialize = JsonConvert.SerializeObject(obj);
                StringContent stringContent = new StringContent(objSerialize, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(uri, stringContent);
                var response = await GetResponse<T>(result);
                return response;
            }
            catch (Exception e)
            {
                return new Response(e.Message, false);
            }
        }




        private async Task<object> GetResponse<T>(HttpResponseMessage result)
        {
            string content = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
                return new Response(result.StatusCode.ToString(), false);

            try
            {
                dynamic obj = JObject.Parse(content);
                var dataJson = JsonConvert.SerializeObject(obj.data);
                var typeObj = JsonConvert.DeserializeObject<T>(dataJson);
                return typeObj;
            }
            catch (Exception e)
            {
                try
                {
                    if (content == string.Empty || content == null)
                        return new Response("Content nulo", false);

                    var response = JsonConvert.DeserializeObject<Response>(content);
                    return response;
                }
                catch
                {
                    return new Response(content, false);
                }
            }
        }
    }
}
