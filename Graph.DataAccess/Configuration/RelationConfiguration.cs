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
    public class RelationConfiguration : IEntityTypeConfiguration<Relation>
    {
        public void Configure(EntityTypeBuilder<Relation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Block)
                .WithMany(x => x.Relations)
                .HasForeignKey(x => x.BlockId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
