using Graph.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.DTOs
{
    public class SaveGraphDTO
    {
        public int Id { get; set; }
        public List<SaveBlockDTO> Blocks { get; set; }
    }

    public class SaveBlockDTO
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsNewBlock { get; set; }
        public List<SaveRelationDTO> Relations { get; set; }
    }

    public class SaveRelationDTO
    {
        public int Id { get; set; }
        public int BlockId { get; set; }
        public int RelatedBlockId { get; set; }
        public int? VectorId { get; set; }
        public double Weight { get; set; }
        public string Type { get; set; }
        public bool IsNew { get; set; }
        public bool Oriented { get; set; }
    }
}
