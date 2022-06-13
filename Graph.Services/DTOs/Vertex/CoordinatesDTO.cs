using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.DTOs.Vertex
{
    public class CoordinatesDTO
    {
        public int GraphId { get; set; }
        public List<CoordinatesItemDTO> List { get; set; }
    }

    public class CoordinatesItemDTO
    {
        public int? Id { get; set; }
        public int BlockId { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
    }
}
