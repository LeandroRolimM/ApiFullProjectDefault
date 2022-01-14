using RLM.Business.Interfaces;
using RLM.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using RLM.Business.Notifications;
using FluentValidation.Results;

namespace RLM.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }


        protected bool ExecutarValidacao<TEntity, TValidator>(TEntity entity, TValidator validator) where TValidator : AbstractValidator<TEntity> where TEntity : Entity
        {
            var result = validator.Validate(entity);

            if (result.IsValid) return true;

            NotificarErro(result);

            return false;
        }


        protected void NotificarErro(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                NotificarErro(erro.ErrorMessage);
            }
        }

        protected void NotificarErro(string erro)
        {
            _notificador.Handle(new Notificacao(erro));
        }

    }
}
