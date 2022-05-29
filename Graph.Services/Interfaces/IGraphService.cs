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
    }
}
