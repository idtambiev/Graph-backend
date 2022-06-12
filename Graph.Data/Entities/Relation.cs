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
        public int? VectorId { get; set; }
        public double Weight { get; set; }
        public string Type { get; set; }
        public bool Oriented { get; set; }
        public string Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public virtual Block Block { get; set; }
        public virtual Vector Vector { get; set; }


        public Relation Create(int blockId, int relatedId, double weight, string type)
        {
            Relation relation = new Relation()
            {
                BlockId = blockId,
                RelatedId = relatedId,
                Weight = weight,
                Type = type,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsActive = true,
            };

            return relation;
        }
    }
}
