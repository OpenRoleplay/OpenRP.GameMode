﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenRP.GameMode.Data;

namespace OpenRP.GameMode.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221204181044_NationalitiesTable")]
    partial class NationalitiesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("OpenRP.GameMode.Data.Models.Account", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<byte?>("CountryOfBirthId")
                        .HasColumnType("tinyint unsigned");

                    b.Property<ushort>("Experience")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint unsigned")
                        .HasDefaultValue((ushort)0);

                    b.Property<byte>("Level")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint unsigned")
                        .HasDefaultValue((byte)1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("char(60)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(24)");

                    b.HasKey("Id");

                    b.HasIndex("CountryOfBirthId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("OpenRP.GameMode.Data.Models.Character", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Accent")
                        .HasColumnType("varchar(30)");

                    b.Property<ulong?>("AccountId")
                        .HasColumnType("bigint unsigned");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<ulong?>("InventoryId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("InventoryId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("OpenRP.GameMode.Data.Models.Inventory", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<int?>("MaxWeight")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Inventories");

                    b.HasData(
                        new
                        {
                            Id = 1ul,
                            Name = "World Inventory"
                        });
                });

            modelBuilder.Entity("OpenRP.GameMode.Data.Models.Nationality", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Nationalities");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Name = "Native of San Andreas"
                        },
                        new
                        {
                            Id = (byte)2,
                            Name = "Russian"
                        });
                });

            modelBuilder.Entity("OpenRP.GameMode.Data.Models.Account", b =>
                {
                    b.HasOne("OpenRP.GameMode.Data.Models.Nationality", "CountryOfBirth")
                        .WithMany()
                        .HasForeignKey("CountryOfBirthId");

                    b.Navigation("CountryOfBirth");
                });

            modelBuilder.Entity("OpenRP.GameMode.Data.Models.Character", b =>
                {
                    b.HasOne("OpenRP.GameMode.Data.Models.Account", null)
                        .WithMany("Characters")
                        .HasForeignKey("AccountId");

                    b.HasOne("OpenRP.GameMode.Data.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("OpenRP.GameMode.Data.Models.Account", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
