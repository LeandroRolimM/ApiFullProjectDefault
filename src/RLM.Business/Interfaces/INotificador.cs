using RLM.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace RLM.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();

        IEnumerable<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}
