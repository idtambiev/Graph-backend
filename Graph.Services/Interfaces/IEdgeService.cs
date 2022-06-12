using Graph.Services.DTOs.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.Interfaces
{
    public interface IEdgeService
    {
        Task CreateEdge(CreateEdgeDTO dto);
    }
}
