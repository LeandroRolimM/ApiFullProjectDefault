using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RLM.Business.Interfaces;
using RLM.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RLM.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class MainController: ControllerBase
    {
        private readonly INotificador _notificador;

        public MainController(INotificador notificador)
        {
            _notificador = notificador;
        }


        public IActionResult CustomResponse(object obj = null)
        {
            if(OperacaoValida())
            {
                return Ok(new 
                {
                    Success = true,
                    Data = obj
                });
            }

            return BadRequest( new {
                Success = false,
                Errors=_notificador.ObterNotificacoes()
            });

        }

        public IActionResult CustomResponse(ModelStateDictionary modelState)
        {
            ObterErrosModelState(modelState);
            return CustomResponse();
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        void ObterErrosModelState(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string erro)
        {
            _notificador.Handle(new Notificacao(erro));
        }
    }
}
