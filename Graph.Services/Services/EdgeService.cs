using AutoMapper;
using Graph.DataAccess.Interfaces;
using Graph.Services.DTOs.Edge;
using Graph.Services.Interfaces;
using Graph.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.Services
{
    public class EdgeService: BaseService, IEdgeService
    {
        public EdgeService(IRepository repo, IMapper mapper)
          : base(repo, mapper)
        {
        }

        public async Task CreateEdge(CreateEdgeDTO dto)
        {

        }
    }
}
