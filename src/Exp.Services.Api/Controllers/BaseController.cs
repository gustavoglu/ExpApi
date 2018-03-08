using Exp.Domain.Core.Notifications;
using Exp.Services.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Exp.Services.Api.Controllers
{
    [Produces("application/json")]
    public class BaseController : Controller
    {
        protected new IActionResult Response(object obj = null, bool succes = false)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetErrosModelState());

            return Ok(new Response(obj, true));
        }

        private object GetErrosModelState()
        {
            if (ModelState.IsValid) return null;

            var erros = from modelstateValue in ModelState.Values
                        from erro in modelstateValue.Errors
                        select new Message("ModelState", erro.ErrorMessage);

            return erros.ToList();
        }
    }
}
