﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi.Models;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webapi.Models.kategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("kategoriAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("kategoriler");
                });

            modelBuilder.Entity("webapi.Models.rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("roller");
                });

            modelBuilder.Entity("webapi.Models.urun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CihazAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("durum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("fiyat")
                        .HasColumnType("float");

                    b.Property<int?>("kategoriId")
                        .HasColumnType("int");

                    b.Property<string>("ozellik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("resim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("serino")
                        .HasColumnType("int");

                    b.Property<int>("stok")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("kategoriId");

                    b.ToTable("urunler");
                });

            modelBuilder.Entity("webapi.Models.user", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("rolId")
                        .HasColumnType("int");

                    b.Property<string>("sifre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("telefon")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("rolId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("webapi.Models.urun", b =>
                {
                    b.HasOne("webapi.Models.kategori", "kategori")
                        .WithMany()
                        .HasForeignKey("kategoriId");

                    b.Navigation("kategori");
                });

            modelBuilder.Entity("webapi.Models.user", b =>
                {
                    b.HasOne("webapi.Models.rol", "rol")
                        .WithMany()
                        .HasForeignKey("rolId");

                    b.Navigation("rol");
                });
#pragma warning restore 612, 618
        }
    }
}