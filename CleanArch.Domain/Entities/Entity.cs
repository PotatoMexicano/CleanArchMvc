using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public DateTime CreateAt { get; protected set; }
        public string Hash { get; protected set; }

        protected Entity()
        {
            CreateAt = DateTime.Now;
        }
    }
}
