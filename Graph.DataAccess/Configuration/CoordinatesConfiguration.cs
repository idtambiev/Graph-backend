using Graph.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.DataAccess.Configuration
{
    public class CoordinatesConfiguration : IEntityTypeConfiguration<Coordinates>
    {
        public void Configure(EntityTypeBuilder<Coordinates> builder)
        {
            
        }
    }
}
