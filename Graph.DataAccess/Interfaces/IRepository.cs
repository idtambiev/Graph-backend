using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.DataAccess.Interfaces
{
    public interface IRepository
    {
        public GraphDbContext Context { get; }
    }
}
