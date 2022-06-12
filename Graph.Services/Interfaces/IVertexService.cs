using Graph.Services.DTOs.Vertex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.Interfaces
{
    public interface IVertexService
    {
        Task CreateVertex(CreateVertexDTO dto);
    }
}
