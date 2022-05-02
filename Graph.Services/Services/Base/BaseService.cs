using Graph.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.Services.Base
{
    public class BaseService
    {
        public IRepository _repo;
        public BaseService(IRepository repo)
        {
            _repo = repo;
        }
    }
}
