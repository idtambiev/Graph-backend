﻿// <auto-generated />
using System;
using Graph.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Graph.DataAccess.Migrations
{
    [DbContext(typeof(GraphDbContext))]
    [Migration("20220612232619_added-coordinates")]
    partial class addedcoordinates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Graph.Data.Entities.Block", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GraphId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GraphId");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("Graph.Data.Entities.Coordinates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlockId")
                        .HasColumnType("int");

                    b.Property<int>("XCoordinate")
                        .HasColumnType("int");

                    b.Property<int>("YCoordinate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BlockId")
                        .IsUnique();

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("Graph.Data.Entities.GraphEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Graphs");
                });

            modelBuilder.Entity("Graph.Data.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Graph.Data.Entities.Relation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlockId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("Oriented")
                        .HasColumnType("bit");

                    b.Property<int>("RelatedId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VectorId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BlockId");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("Graph.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Graph.Data.Entities.Vector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("RelationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RelationId")
                        .IsUnique();

                    b.ToTable("Vectors");
                });

            modelBuilder.Entity("Graph.Data.Entities.VectorItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VectorId")
                        .HasColumnType("int");

                    b.Property<bool>("VectorTowards")
                        .HasColumnType("bit");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("VectorId");

                    b.ToTable("VectorItems");
                });

            modelBuilder.Entity("Graph.Data.Entities.Block", b =>
                {
                    b.HasOne("Graph.Data.Entities.GraphEntity", "Graph")
                        .WithMany("Blocks")
                        .HasForeignKey("GraphId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Graph");
                });

            modelBuilder.Entity("Graph.Data.Entities.Coordinates", b =>
                {
                    b.HasOne("Graph.Data.Entities.Block", "Block")
                        .WithOne("Coordinates")
                        .HasForeignKey("Graph.Data.Entities.Coordinates", "BlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Block");
                });

            modelBuilder.Entity("Graph.Data.Entities.GraphEntity", b =>
                {
                    b.HasOne("Graph.Data.Entities.User", "User")
                        .WithMany("Graphs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Graph.Data.Entities.RefreshToken", b =>
                {
                    b.HasOne("Graph.Data.Entities.User", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("Graph.Data.Entities.RefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Graph.Data.Entities.Relation", b =>
                {
                    b.HasOne("Graph.Data.Entities.Block", "Block")
                        .WithMany("Relations")
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Block");
                });

            modelBuilder.Entity("Graph.Data.Entities.Vector", b =>
                {
                    b.HasOne("Graph.Data.Entities.Relation", "Relation")
                        .WithOne("Vector")
                        .HasForeignKey("Graph.Data.Entities.Vector", "RelationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Relation");
                });

            modelBuilder.Entity("Graph.Data.Entities.VectorItem", b =>
                {
                    b.HasOne("Graph.Data.Entities.Vector", "Vector")
                        .WithMany("VectorItems")
                        .HasForeignKey("VectorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Vector");
                });

            modelBuilder.Entity("Graph.Data.Entities.Block", b =>
                {
                    b.Navigation("Coordinates");

                    b.Navigation("Relations");
                });

            modelBuilder.Entity("Graph.Data.Entities.GraphEntity", b =>
                {
                    b.Navigation("Blocks");
                });

            modelBuilder.Entity("Graph.Data.Entities.Relation", b =>
                {
                    b.Navigation("Vector");
                });

            modelBuilder.Entity("Graph.Data.Entities.User", b =>
                {
                    b.Navigation("Graphs");

                    b.Navigation("RefreshToken");
                });

            modelBuilder.Entity("Graph.Data.Entities.Vector", b =>
                {
                    b.Navigation("VectorItems");
                });
#pragma warning restore 612, 618
        }
    }
}
