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
    [Migration("20221127125455_Inventory")]
    partial class Inventory
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

                    b.Property<ushort>("Experience")
                        .HasColumnType("smallint unsigned");

                    b.Property<byte>("Level")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("char(128)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("char(10)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(24)");

                    b.HasKey("Id");

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
                        .HasColumnType("varchar(35)");

                    b.Property<ulong?>("InventoryId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("LastName")
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

                    b.Property<int>("MaxWeightInGrams")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Inventories");
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
