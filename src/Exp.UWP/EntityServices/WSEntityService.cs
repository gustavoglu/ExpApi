using Exp.Domain.Core.Models;
using Exp.UWP.Interfaces;
using Exp.UWP.WS;
using System;
using System.Threading.Tasks;

namespace Exp.UWP.EntityServices
{
    public class WSEntityService<T> : IWSEntityService<T> where T : Entity
    {
        private string _uriPadrao;
        private readonly WSService wsService;
        public WSEntityService(string uriPadrao)
        {
            _uriPadrao = uriPadrao;
            wsService = new WSService();
        }

        public async Task Atualiza(T entity)
        {
            var result = await wsService.Put(_uriPadrao, entity);
            ValidaResponse(result);
        }

        public async Task Cria(T entity)
        {
            var result = await wsService.Post(_uriPadrao, entity);
            ValidaResponse(result);
        }

        public async Task Deleta(Guid id)
        {
            var result = await wsService.Delete(_uriPadrao, id);
            ValidaResponse(result);
        }

        public bool ValidaResponse(object result)
        {
            if(result.GetType() == typeof(Response))
            {
                var response = (Response)result;
                Message.Erro((string)response.Data);
                return false;
            }

            return true;
        }
    }
}
