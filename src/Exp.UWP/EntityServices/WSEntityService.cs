
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

        public async Task<bool> Atualiza(T entity)
        {
            var result = await wsService.Put(_uriPadrao, entity);
            return ValidaResponse(result);
        }

        public async Task<bool> Cria(T entity)
        {
            var result = await wsService.Post(_uriPadrao, entity);
            return ValidaResponse(result);
        }

        public async Task<bool> Deleta(Guid id)
        {
            var result = await wsService.Delete(_uriPadrao, id);
            return ValidaResponse(result);
        }

        public bool ValidaResponse(object result)
        {
            try
            {
                if (result.GetType() == typeof(Response))
                {
                    var response = (Response)result;
                    Message.Erro((string)response.Data);
                    return false;
                }

                return true;
            }catch(Exception e)
            {
                Message.Erro(e.Message);
                return false;
            }
        }
    }
}
