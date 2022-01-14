using System;
using System.Collections.Generic;
using System.Text;

namespace RLM.Business.Models
{
    public abstract class Entity
    {
        protected Guid  Id { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        
    }
}
