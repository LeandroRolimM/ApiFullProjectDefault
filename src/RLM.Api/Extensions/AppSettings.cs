using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RLM.Api.Extensions
{
    public class AppSettings
    {
        public string Segredo { get; set; }

        public int ExpiracaoEmHoras { get; set; }

        public string Emissor { get; set; }

        public string Audiencia { get; set; }
    }
}
