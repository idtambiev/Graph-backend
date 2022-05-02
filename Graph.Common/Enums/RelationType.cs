using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Common.Enums
{
    public enum RelationType
    {
        OneTypeUndirected = 0,
        OneTypeOriented = 1,
        DiverseUndirected = 2,
        DiverseOriented = 3,
        MultipleUndirectedVector = 4,
        MultipleOrientedVector = 5
    }
}
