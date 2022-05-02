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
    public class GraphConfiguration : IEntityTypeConfiguration<Data.Entities.Graph>
    {
        public void Configure(EntityTypeBuilder<Data.Entities.Graph> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Blocks)
                .WithOne()
                .HasForeignKey(x => x.GraphId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Graphs)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
