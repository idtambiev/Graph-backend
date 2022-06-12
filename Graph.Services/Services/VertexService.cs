using AutoMapper;
using Graph.Data.Entities;
using Graph.DataAccess.Interfaces;
using Graph.Services.DTOs.Vertex;
using Graph.Services.Interfaces;
using Graph.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.Services
{
    public class VertexService : BaseService, IVertexService
    {
        public VertexService(IRepository repo, IMapper mapper)
          : base(repo, mapper)
        {
            //_mapper = mapper;
        }

        public async Task CreateVertex(CreateVertexDTO dto)
        {
            var newVertex = new Block().Create(dto.GraphId, dto.Value);

            await _repo.Context.Blocks.AddAsync(newVertex);
            await _repo.Context.SaveChangesAsync();
        }
    }
}
