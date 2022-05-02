using Graph.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Data.Entities
{
    public class RefreshToken: IEntityWithId, IBase
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public User User { get; set; }

    }
}
