using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Data.Entities.Base
{
    public interface IEntityWithGuid
    {
        public Guid Id { get; set; }
    }
}
