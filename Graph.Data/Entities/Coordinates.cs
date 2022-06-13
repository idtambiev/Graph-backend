using Graph.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Data.Entities
{
    public class Coordinates : IEntityWithId
    {
        public int Id { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int BlockId { get; set; }
        public int GraphId { get; set; }
        public Block Block { get; set; }

    }
}
