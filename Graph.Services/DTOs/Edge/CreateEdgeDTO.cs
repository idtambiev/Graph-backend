using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.DTOs.Edge
{
    public class CreateEdgeDTO
    {
        public int BlockId { get; set; }
        public int RelatedId { get; set; }
        public double Weight { get; set; }
        public string Type { get; set; }
        public bool Oriented { get; set; }
        public string Value { get; set; }
        public int? VectorId { get; set; }
    }
}
