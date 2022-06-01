using Graph.Common.Models;
using Graph.DataAccess.Interfaces;
using Graph.Services.DTOs;
using Graph.Services.Interfaces;
using Graph.Services.Services.Base;
using Microsoft.EntityFrameworkCore;
using Graph.Data.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using AutoMapper;
using System.Collections.Generic;

namespace Graph.Services.Services
{
    public class GraphService : BaseService, IGraphService
    {
        //private readonly IMapper _mapper;
        public GraphService(IRepository repo, IMapper mapper)
            : base(repo, mapper)
        {
            //_mapper = mapper;
        }

        public async Task<ListResult<GraphItemDTO>> GetGraphsList(string userId)
        {
            var graphs = await _repo.Context.Graphs
                .Where(g => g.UserId.ToString() == userId && g.IsActive)
                .Select(x => new GraphItemDTO { Id = x.Id, Name = x.Name })
                .ToListAsync();

            ListResult<GraphItemDTO> result = new ListResult<GraphItemDTO> 
            { 
                Items = graphs,
                Total = graphs.Count
            };


            return result;
        }

        public async Task CreateGraph(string userId, CreateGraphDTO dto)
        {
            GraphEntity graph = new GraphEntity().Create(userId, dto.Name);
            await _repo.Context.Graphs.AddAsync(graph);
            await _repo.Context.SaveChangesAsync();
        }

        public async Task<GetGraphDTO> GetGraphById(int id)
        {
            var graphEntity = await _repo.Context.Graphs
                .Include(x => x.Blocks)
                .ThenInclude(x => x.Relations)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (graphEntity == null)
            {
                throw new Exception("Graph with that id does not exist");
            }

            var result = _mapper.Map<GetGraphDTO>(graphEntity);

            result.Blocks = _mapper.Map<List<GetBlockDTO>>(graphEntity.Blocks);
            
            return result;
        }

        public async Task SaveGraph(string userId, SaveGraphDTO dto)
        {
            var existedGraph = await _repo.Context.Graphs
                .Include(x => x.Blocks)
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (existedGraph == null)
            {
                // CreateNewGraph(userId, dto);
            } else
            {
                foreach (var block in dto.Blocks)
                {
                    if (block.IsNewBlock)
                    {
                        var newBlock = new Block().Create(existedGraph.Id, block.Value);
                        existedGraph.Blocks.Add(newBlock);
                    }
                }

                _repo.Context.Graphs.Update(existedGraph);

                await _repo.Context.SaveChangesAsync();

                await SaveRelations(dto);

            }

        }

        private async Task<bool> SaveVector(SaveGraphDTO dto)
        {
            try
            {

                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        private async Task<bool> SaveRelations(SaveGraphDTO dto)
        {
            try
            {
                var graphForRelations = await _repo.Context.Graphs
                    .Include(x => x.Blocks)
                    .FirstOrDefaultAsync(x => x.Id == dto.Id);

                foreach (var block in dto.Blocks)
                {
                    foreach (var relation in block.Relations)
                    {
                        if (relation.IsNew)
                        {
                            bool checkSrcBlock = CheckIsNewBlockRelation(dto.Blocks, relation.BlockId);
                            bool checkDestBlock = CheckIsNewBlockRelation(dto.Blocks, relation.RelatedBlockId);

                            if (!checkSrcBlock && !checkDestBlock)
                            {
                                var existedBlock = graphForRelations.Blocks.FirstOrDefault(x => x.Id == relation.BlockId);
                                if (existedBlock == null)
                                {
                                    throw new Exception("Block does not exist");
                                }
                                var mappingResult = _mapper.Map<Relation>(relation);
                                mappingResult.Block = existedBlock;
                                mappingResult.BlockId = relation.BlockId;
                                mappingResult.Id = 0;

                                _repo.Context.Relations.Add(mappingResult);
                            }
                        }
                    }
                }


                await _repo.Context.SaveChangesAsync();
                return true;
            }catch (Exception ex)
            {
                return false;
            }

            
        }

        public async Task DeleteGraph(int id)
        {
            var existedGraph = await _repo.Context.Graphs
                .Include(x => x.Blocks)
                .ThenInclude(x => x.Relations)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existedGraph == null)
            {
                throw new Exception("Error");
            }
            existedGraph.IsActive = false;

            existedGraph.Blocks.ForEach(x => x.IsActive = false);

            _repo.Context.Graphs.Update(existedGraph);
            await _repo.Context.SaveChangesAsync();
        }


        private bool CheckIsNewBlockRelation(List<SaveBlockDTO> blocks, int blockId)
        {
            var block = blocks.First(x => x.Id == blockId);
            return block.IsNewBlock;
        }
        private async void CreateNewGraph(string userId, SaveGraphDTO dto)
        {
            //var graph = new GraphEntity().Create(userId, dto.Name);
            
            //foreach(var block in dto.Blocks)
            //{
            //    var newBlock = new Block().Create(block.Value);
            //    graph.Blocks.Add(newBlock);
            //}

            //await _repo.Context.SaveChangesAsync();
            //var a = graph.Blocks;
        }

        //private async void UpdateGraph(GraphEntity entity, SaveGraphDTO dto)
        //{
            
        //}
    }
}
