using Graph.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Data.Entities
{
    public class GraphEntity: IEntityWithId, IBase
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public List<Block> Blocks { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        public GraphEntity Create(string userId, string name)
        {
            GraphEntity graph = new GraphEntity() 
            { 
                UserId = Guid.Parse(userId),
                Name = name,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsActive = true,
            };

            return graph;
        }
    }
}
