using Graph.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Data.Entities
{
    public class Vector : IEntityWithId, IBase
    {
        public int Id { get; set; }
        public int GraphId { get; set; }
        public List<VectorItem> VectorItems { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public GraphEntity GraphEntity { get; set; }

    }
}
