using Graph.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Data.Entities
{
    public class Block: IEntityWithId, IBase
    {
        public int Id { get; set; }
        public int GraphId { get; set; }
        public string Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public List<Relation> Relations { get; set; }
        public GraphEntity Graph { get; set; }
    }
}
