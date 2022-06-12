using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.DTOs.Edge
{
    public class CreateEdgeDTO
    {
        public int GraphId { get; set; }
        public string Value { get; set; }
    }
}
