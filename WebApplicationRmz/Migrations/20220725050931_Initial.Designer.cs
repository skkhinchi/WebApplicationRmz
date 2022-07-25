﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationRmz.Data;

namespace WebApplicationRmz.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220725050931_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebApplicationRmz.Models.Building", b =>
                {
                    b.Property<int>("BId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FId")
                        .HasColumnType("int");

                    b.HasKey("BId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("WebApplicationRmz.Models.Facility", b =>
                {
                    b.Property<int>("FId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FId");

                    b.ToTable("Facilites");
                });

            modelBuilder.Entity("WebApplicationRmz.Models.Zone", b =>
                {
                    b.Property<int>("ZId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BId")
                        .HasColumnType("int");

                    b.Property<int>("FId")
                        .HasColumnType("int");

                    b.Property<string>("ZName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZId");

                    b.ToTable("Zones");
                });
#pragma warning restore 612, 618
        }
    }
}