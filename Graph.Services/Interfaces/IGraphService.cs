using Graph.Common.Models;
using Graph.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.Interfaces
{
    public interface IGraphService
    {
        Task<ListResult<GraphItemDTO>> GetGraphsList(string userId);
        Task CreateGraph(string userId, CreateGraphDTO dto);
        Task<GetGraphDTO> GetGraphById(int id);
        Task SaveGraph(string userId, SaveGraphDTO dto);
        Task DeleteGraph(int id);
    }
}
