using AutoMapper;
using Graph.Data.Entities;
using Graph.DataAccess.Interfaces;
using Graph.Services.DTOs.Vertex;
using Graph.Services.Interfaces;
using Graph.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task SaveCoordinates(CoordinatesDTO dto)
        {
            try
            {
                foreach (var obj in dto.List)
                {
                    var coordinate = _repo.Context.Coordinates.FirstOrDefault(x => x.BlockId == obj.BlockId);
                    if (coordinate != null)
                    {
                        coordinate.XCoordinate = obj.XCoordinate;
                        coordinate.YCoordinate = obj.YCoordinate;
                        _repo.Context.Coordinates.Update(coordinate);
                    }
                    else
                    {
                        var newCoordinates = new Coordinates()
                        {
                            XCoordinate = obj.XCoordinate,
                            YCoordinate = obj.YCoordinate,
                            BlockId = obj.BlockId,
                            GraphId = dto.GraphId
                        };

                        await _repo.Context.Coordinates.AddAsync(newCoordinates);
                    }
                }
                await _repo.Context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CoordinatesDTO> GetCoordinatesByGraphId(int graphId)
        {
            try
            {
                var list = _repo.Context.Coordinates
                    .Where(x => x.GraphId == graphId)
                    .ToList();

                var result = new CoordinatesDTO();

                result.GraphId = graphId;
                result.List = _mapper.Map<List<CoordinatesItemDTO>>(list);
                return result;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
