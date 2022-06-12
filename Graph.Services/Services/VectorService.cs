using AutoMapper;
using Graph.Data.Entities;
using Graph.DataAccess.Interfaces;
using Graph.Services.DTOs.Vector;
using Graph.Services.Interfaces;
using Graph.Services.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.Services
{
    public class VectorService: BaseService, IVectorService
    {
        public VectorService(IRepository repo, IMapper mapper)
            : base(repo, mapper)
        {

        }


        public async Task CreateVector(CreateVectorDTO dto)
        {
            var newVector = _mapper.Map<Vector>(dto);

            _repo.Context.Vectors.Add(newVector);
            await _repo.Context.SaveChangesAsync();
        }

        public async Task<List<VectorDTO>> GetVectorsListById(int graphId)
        {
            var list = await _repo.Context.Vectors
                .Include(x => x.VectorItems)
                .Where(x => x.RelationId == graphId)
                .ToListAsync();

            var mapperResult = _mapper.Map<List<VectorDTO>>(list);
            return mapperResult;
        }
    }
}
