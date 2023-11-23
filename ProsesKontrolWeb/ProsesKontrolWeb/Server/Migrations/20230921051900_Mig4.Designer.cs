﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProsesKontrolWeb.Server.Data;

#nullable disable

namespace ProsesKontrolWeb.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230921051900_Mig4")]
    partial class Mig4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProsesKontrolWeb.Shared.Models.ImageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FileExtension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.Property<int>("TableInsideId")
                        .HasColumnType("int");

                    b.Property<string>("UniqueStrId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ImageModels");
                });

            modelBuilder.Entity("ProsesKontrolWeb.Shared.Models.ProsesKontrolModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("HataTipi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KontrolMetodu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Operator")
                        .HasColumnType("bit");

                    b.Property<string>("OperatorKontrol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProsesId")
                        .HasColumnType("int");

                    b.Property<bool?>("ProsesKontrolSorumlusu")
                        .HasColumnType("bit");

                    b.Property<string>("ProsesSorumlusuKontrol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Standart")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProsesKontrolModels");
                });

            modelBuilder.Entity("ProsesKontrolWeb.Shared.Models.ProsesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProsesModels");
                });
#pragma warning restore 612, 618
        }
    }
}
