using AutoMapper;
using Graph.Data.Entities;
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
            var newRelation = new Relation()
                .Create(dto.BlockId, dto.RelatedId, dto.Weight, dto.Type, dto.Value);

            await _repo.Context.Relations.AddAsync(newRelation);
            await _repo.Context.SaveChangesAsync();
        }
    }
}
