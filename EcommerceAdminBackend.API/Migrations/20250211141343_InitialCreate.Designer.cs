﻿// <auto-generated />
using System;
using EcommerceAdminBackend.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcommerceAdminBackend.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250211141343_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcommerceAdminBackend.API.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Application")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Coating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompetenceCenter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Diameter")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DiameterUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EdgeFinish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExtraInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Finish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FireClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Index")
                        .HasColumnType("int");

                    b.Property<decimal?>("Length")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LengthUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackagingUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PackagingUnitId")
                        .HasColumnType("int");

                    b.Property<string>("PricingUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PricingUnitId")
                        .HasColumnType("int");

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductSegmentation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<decimal?>("R")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Thickness")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ThicknessUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Volume")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VolumeUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WeightUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Width")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WidthUnit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("EcommerceAdminBackend.API.Models.ArticlePackagingBreakdown", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cubes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("FromFactor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FromUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FromUnitId")
                        .HasColumnType("int");

                    b.Property<bool>("IsERP")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMinimumPackaging")
                        .HasColumnType("bit");

                    b.Property<bool>("StatusInUse")
                        .HasColumnType("bit");

                    b.Property<decimal>("ToFactor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ToUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToUnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ArticlePackagingBreakdowns");
                });

            modelBuilder.Entity("EcommerceAdminBackend.API.Models.ArticleXAvailableStock", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("CompanyStockLocationId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<decimal?>("ActualStock")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AvailableStock")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MaximumStock")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MinimumStock")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ArticleId", "CompanyStockLocationId");

                    b.ToTable("ArticleXAvailableStocks");
                });

            modelBuilder.Entity("EcommerceAdminBackend.API.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressPostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedTS")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerContactId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VatNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Web")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
