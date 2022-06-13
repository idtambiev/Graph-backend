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
    public class BlockConfiguration : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Graph)
                .WithMany(x => x.Blocks)
                .HasForeignKey(x => x.GraphId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Relations)
                .WithOne(x => x.Block)
                .HasForeignKey(x => x.BlockId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Coordinates)
                .WithOne(x => x.Block)
                .HasForeignKey<Coordinates>(x => x.BlockId);
        }
    }
}
