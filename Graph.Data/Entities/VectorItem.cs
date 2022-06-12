using Graph.Common.Enums;
using Graph.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Data.Entities
{
    public class VectorItem: IEntityWithId, IBase
    {
        public int Id { get; set; }
        public RelationType Type { get; set; }
        public string Value { get; set; }
        public double Weight { get; set; }
        public int VectorId { get; set; }
        public bool VectorTowards { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public Vector Vector { get; set; }
    }
}