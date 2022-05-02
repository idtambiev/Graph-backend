using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Data.Entities.Base
{
    public interface IEntityWithId
    {
        public int Id { get; set; }
        
    }
}
