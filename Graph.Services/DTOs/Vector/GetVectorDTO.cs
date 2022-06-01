using Graph.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.DTOs.Vector
{
    public class VectorDTO
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public double MinWeight { get; set; }
        public List<VectorItemDTO> Items { get; set; }
    }

    public class VectorItemDTO
    { 
        public int Id { get; set; }
        public RelationType Type { get; set; }
        public double Weight { get; set; }
        public string Value { get; set; }

    }

}
