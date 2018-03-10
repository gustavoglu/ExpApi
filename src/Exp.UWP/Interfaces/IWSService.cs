using Exp.Infra.Identity.ViewModels;
using System;
using System.Threading.Tasks;

namespace Exp.UWP.Interfaces
{
    public interface IWSService
    {
        Task<object> Post<T>(string uri, T obj);
        Task<object> Get<T>(string uri);
        Task<object> Put<T>(string uri, T obj);
        Task<object> Delete(string uri, Guid id);
        Task<object> Login(LoginViewModel loginViewModel);
    }
}
