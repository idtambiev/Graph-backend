using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Common.Models
{
    public class ListResult<T>
    {
        public List<T> Items { get; set; }
        public int Total { get; set; }
    }
}
