using Graph.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.DTOs
{
    public class GetGraphDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetBlockDTO> Blocks { get; set; }
        public int RelationsCount { get; set; }
    }

    public class GetBlockDTO 
    {
        public int Id { get; set; }
        public int GraphId { get; set; }
        public string Value { get; set; }
        public bool IsNewBlock { get; set; }
        public int Number { get; set; }
        public List<GetRelationDTO> Relations { get; set; }
    }

    public class GetRelationDTO
    {
        public int Id { get; set; }
        public int BlockId { get; set; }
        public int RelatedBlockId { get; set; }
        public double Weight { get; set; }
        public string Type { get; set; }
        public bool IsNew {get;set;}
        public bool Oriented { get; set; }
        public string Value { get; set;}
        public int? VectorId { get; set; }   
    }


}
