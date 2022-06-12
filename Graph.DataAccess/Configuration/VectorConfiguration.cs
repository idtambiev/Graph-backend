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
    public class VectorConfiguration : IEntityTypeConfiguration<Vector>
    {
        public void Configure(EntityTypeBuilder<Vector> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Relation)
                .WithOne(x => x.Vector)
                .HasForeignKey<Vector>(x => x.RelationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.VectorItems)
                .WithOne(x => x.Vector)
                .HasForeignKey(x => x.VectorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
