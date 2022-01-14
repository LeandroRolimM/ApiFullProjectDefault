using RLM.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RLM.Business.Notifications
{
    public class Notificador : INotificador
    {
        private List<Notificacao> Notificacoes;

        public Notificador()
        {
            Notificacoes = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {
            Notificacoes.Add(notificacao);
        }

        public IEnumerable<Notificacao> ObterNotificacoes()
        {
            return Notificacoes;
        }

        public bool TemNotificacao()
        {
            return Notificacoes.Any();
        }
    }
}
