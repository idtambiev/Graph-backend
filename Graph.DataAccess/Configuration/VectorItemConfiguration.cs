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
    public class VectorItemConfiguratioin : IEntityTypeConfiguration<VectorItem>
    {
        public void Configure(EntityTypeBuilder<VectorItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Vector)
                .WithMany(x => x.VectorItems)
                .HasForeignKey(x => x.VectorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
