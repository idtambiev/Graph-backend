using Graph.Data.Entities;
using Graph.DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.DataAccess
{
    public class GraphDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Data.Entities.GraphEntity> Graphs { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Vector> Vectors { get; set; }
        public DbSet<VectorItem> VectorItems { get; set; }
        public DbSet<Coordinates> Coordinates { get; set; }

        public GraphDbContext(DbContextOptions<GraphDbContext> options)
            :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new GraphConfiguration())
                .ApplyConfiguration(new BlockConfiguration())
                .ApplyConfiguration(new RelationConfiguration())
                .ApplyConfiguration(new RefreshTokenConfiguration())
                .ApplyConfiguration(new VectorConfiguration())
                .ApplyConfiguration(new VectorItemConfiguratioin());


        }
    }
}
