﻿using Exp.Domain.Core.Models;
using Exp.Infra.Identity.ViewModels;
using Exp.UWP.Interfaces;
using Newtonsoft.Json;
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
            string uriCompleta = $"{uri}/{id}";
            HttpClient client = new HttpClient();
            var result = await client.DeleteAsync(uriCompleta);
            string content = await result.Content.ReadAsStringAsync();
            var response = await GetResponse<bool>(result);
            return response;
        }


        public async Task<object> Get<T>(string uri)
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(uri);
            var response = await GetResponse<T>(result);
            return response;
        }

        public async Task<object> Login(LoginViewModel loginViewModel)
        {
            string uri = Constantes.SERVER_LOGIN;
            HttpClient client = new HttpClient();
            string objSerialize = JsonConvert.SerializeObject(loginViewModel);
            StringContent stringContent = new StringContent(objSerialize, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(uri, stringContent);
            var response = await GetResponse<TokenContainer>(result);
            return response;
        }

        public async Task<object> Post<T>(string uri, T obj)
        {
            HttpClient client = new HttpClient();
            string objSerialize = JsonConvert.SerializeObject(obj);
            StringContent stringContent = new StringContent(objSerialize, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(uri,stringContent);
            var response = await GetResponse<T>(result);
            return response;
        }

        public async Task<object> Put<T>(string uri, T obj)
        {
            HttpClient client = new HttpClient();
            string objSerialize = JsonConvert.SerializeObject(obj);
            StringContent stringContent = new StringContent(objSerialize, Encoding.UTF8, "application/json");
            var result = await client.PutAsync(uri, stringContent);
            var response = await GetResponse<T>(result);
            return response;
        }




        private async Task<object> GetResponse<T>(HttpResponseMessage result)
        {
            dynamic content = await result.Content.ReadAsStringAsync();
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(content.data);
                return obj;
            }
            catch
            {
                try
                {
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
