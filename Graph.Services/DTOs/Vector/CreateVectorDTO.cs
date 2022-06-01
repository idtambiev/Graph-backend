using Graph.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.DTOs.Vector
{
    public class CreateVectorDTO
    {
        public int GraphId { get; set; }
        public string Value { get; set; }
        public List<CreateVectorItemDTO> Items { get; set; }
    }

    public class CreateVectorItemDTO 
    {
        public string Value { get; set; }
        public RelationType Type { get; set; }
        public double Weight { get; set; }
    }

}
