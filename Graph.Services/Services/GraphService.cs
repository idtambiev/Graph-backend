﻿using Graph.Common.Models;
using Graph.DataAccess.Interfaces;
using Graph.Services.DTOs;
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
    public class GraphService : BaseService, IGraphService
    {
        public GraphService(IRepository repo)
            : base(repo)
        {

        }

        public async Task<ListResult<GraphItemDTO>> GetGraphsList(string userId)
        {
            var graphs = await _repo.Context.Graphs
                .Where(g => g.UserId.ToString() == userId)
                .Select(x => new GraphItemDTO { Id = x.Id, Name = x.Name })
                .ToListAsync();

            ListResult<GraphItemDTO> result = new ListResult<GraphItemDTO> 
            { 
                Items = graphs,
                Total = graphs.Count
            };


            return result;
        }
    }
}
