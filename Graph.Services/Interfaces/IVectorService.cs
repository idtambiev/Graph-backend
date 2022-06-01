using Graph.Services.DTOs.Vector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.Interfaces
{
    public interface IVectorService
    {
        Task CreateVector(CreateVectorDTO dto);
        Task<List<VectorDTO>> GetVectorsListById(int graphId);
    }
}
