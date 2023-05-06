﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MueblesDiamante.Models;

#nullable disable

namespace MueblesDiamante.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MueblesDiamante.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("UserCreator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserModifier")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2023, 5, 5, 23, 22, 46, 212, DateTimeKind.Local).AddTicks(9549),
                            ModificationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Muebles",
                            StatusId = 1,
                            UserCreator = "DefaultUser"
                        });
                });

            modelBuilder.Entity("MueblesDiamante.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("UserCreator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserModifier")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("StatusId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Color = "Naranja",
                            CreationDate = new DateTime(2023, 5, 5, 23, 22, 46, 213, DateTimeKind.Local).AddTicks(5802),
                            Description = "Divan elegante de color naranja grande",
                            Image = "NO DISPONIBLE",
                            ModificationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Divan De Ceda",
                            Price = 4999.99m,
                            StatusId = 1,
                            UserCreator = "DefaultUser"
                        });
                });

            modelBuilder.Entity("MueblesDiamante.Models.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCreator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserModifier")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2023, 5, 5, 23, 22, 46, 213, DateTimeKind.Local).AddTicks(9475),
                            ModificationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Activo",
                            UserCreator = "DefaultUser"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2023, 5, 5, 23, 22, 46, 213, DateTimeKind.Local).AddTicks(9480),
                            ModificationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Inactivo",
                            UserCreator = "DefaultUser"
                        });
                });

            modelBuilder.Entity("MueblesDiamante.Models.Entities.Category", b =>
                {
                    b.HasOne("MueblesDiamante.Models.Entities.Status", "Status")
                        .WithMany("Categories")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MueblesDiamante.Models.Entities.Product", b =>
                {
                    b.HasOne("MueblesDiamante.Models.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MueblesDiamante.Models.Entities.Status", "Status")
                        .WithMany("Products")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MueblesDiamante.Models.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MueblesDiamante.Models.Entities.Status", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
