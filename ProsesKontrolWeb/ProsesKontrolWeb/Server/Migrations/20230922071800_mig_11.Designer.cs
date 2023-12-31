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
    [Migration("20230922071800_mig_11")]
    partial class mig_11
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

                    b.Property<bool?>("ProsesKontrolSorumlusu")
                        .HasColumnType("bit");

                    b.Property<int?>("ProsesModelId")
                        .HasColumnType("int");

                    b.Property<string>("ProsesSorumlusuKontrol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Standart")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProsesModelId");

                    b.ToTable("ProsesKontrolModels");
                });

            modelBuilder.Entity("ProsesKontrolWeb.Shared.Models.ProsesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Birim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("IsSuresi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("KalipAyarSuresi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SaatlikUretimMiktari")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProsesModels");
                });

            modelBuilder.Entity("ProsesKontrolWeb.Shared.Models.ProsesKontrolModel", b =>
                {
                    b.HasOne("ProsesKontrolWeb.Shared.Models.ProsesModel", "ProsesModel")
                        .WithMany()
                        .HasForeignKey("ProsesModelId");

                    b.Navigation("ProsesModel");
                });
#pragma warning restore 612, 618
        }
    }
}
