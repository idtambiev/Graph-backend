using Graph.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.DataAccess.Repositories
{
    public class Repository: IRepository
    {
        public GraphDbContext Context { get; set; }

        public Repository(GraphDbContext _context)
        {
            Context = _context;
        }
    }
}
