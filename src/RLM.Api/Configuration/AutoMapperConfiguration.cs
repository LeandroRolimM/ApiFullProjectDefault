using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RLM.Api.Configuration
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration()
        {
            // Referencia: CreateMap<Viewmodel, Entidade>();
        }
    }
}
