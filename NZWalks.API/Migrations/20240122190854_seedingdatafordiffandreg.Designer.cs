﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalks.API.Data;

#nullable disable

namespace NZWalks.API.Migrations
{
    [DbContext(typeof(NZWalksDbContext))]
    [Migration("20240122190854_seedingdatafordiffandreg")]
    partial class seedingdatafordiffandreg
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalks.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficultys");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b974dfc-f341-4f96-b806-5a33d9fab18e"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("e941cda3-902d-4088-a349-3f04390454ec"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("67fcfa6a-9c3d-425b-a529-74c017fedbd1"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("68fd2b61-45a7-4c92-b81a-9dfb85a1d3e5"),
                            Code = "AKL",
                            Name = "Auckland",
                            RegionImageUrl = "SomeAucklandImage.jpg"
                        },
                        new
                        {
                            Id = new Guid("e9c4f3a8-7bcf-473d-b0d8-2c9d3feef98d"),
                            Code = "NTL",
                            Name = "Northland",
                            RegionImageUrl = "SomeNorthlandImage.jpg"
                        },
                        new
                        {
                            Id = new Guid("36a7d891-22e5-4f3b-8a56-61b92a58d7c2"),
                            Code = "BOP",
                            Name = "Bay of Plenty",
                            RegionImageUrl = "SomeBopImage.jpg"
                        },
                        new
                        {
                            Id = new Guid("d4320f6b-9f2c-4ee4-a9db-815e02b7c5e1"),
                            Code = "WLG",
                            Name = "Wellington",
                            RegionImageUrl = "SomeWellingtonImage.jpg"
                        },
                        new
                        {
                            Id = new Guid("a5e37c91-7f9d-45b1-b7cc-c0a3f2a6bd8e"),
                            Code = "NSN",
                            Name = "Nelson",
                            RegionImageUrl = "SomeNelsonImage.jpg"
                        },
                        new
                        {
                            Id = new Guid("8f462aa2-6152-48a5-b6ef-3d90b8f76b8f"),
                            Code = "STL",
                            Name = "Southland",
                            RegionImageUrl = "SomeSouthlandImage.jpg"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZWalks.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalks.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
