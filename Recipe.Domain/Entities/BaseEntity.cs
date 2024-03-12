using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain.Entities
{
    public abstract  class BaseEntity
    {
        public virtual int Id { get;  set; }
    }
}
