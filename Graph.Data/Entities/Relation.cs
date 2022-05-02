using Graph.Common.Enums;
using Graph.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Data.Entities
{
    public class Relation: IEntityWithId, IBase
    {
        public int Id { get; set; }
        public int BlockId { get; set; }
        public int RelatedId { get; set; }
        public double Weight { get; set; }
        public RelationType Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public Block Block { get; set; }
    }
}
