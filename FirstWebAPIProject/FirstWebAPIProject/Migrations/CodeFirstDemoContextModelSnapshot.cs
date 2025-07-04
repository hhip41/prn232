﻿// <auto-generated />
using System;
using FirstWebAPIProject.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FirstWebAPIProject.Migrations
{
    [DbContext(typeof(CodeFirstDemoContext))]
    partial class CodeFirstDemoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FirstWebAPIProject.Models.InstrumentType", b =>
                {
                    b.Property<int>("InstrumentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstrumentTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstrumentTypeId");

                    b.ToTable("InstrumentTypes");
                });

            modelBuilder.Entity("FirstWebAPIProject.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FirstWebAPIProject.Models.PlayerInstrument", b =>
                {
                    b.Property<int>("PlayerInstrumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerInstrumentId"));

                    b.Property<int>("InstrumentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("PlayerInstrumentId");

                    b.HasIndex("InstrumentTypeId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerInstruments");
                });

            modelBuilder.Entity("FirstWebAPIProject.Models.PlayerInstrument", b =>
                {
                    b.HasOne("FirstWebAPIProject.Models.InstrumentType", "InstrumentType")
                        .WithMany("PlayerInstruments")
                        .HasForeignKey("InstrumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirstWebAPIProject.Models.Player", "Player")
                        .WithMany("PlayerInstruments")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InstrumentType");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("FirstWebAPIProject.Models.InstrumentType", b =>
                {
                    b.Navigation("PlayerInstruments");
                });

            modelBuilder.Entity("FirstWebAPIProject.Models.Player", b =>
                {
                    b.Navigation("PlayerInstruments");
                });
#pragma warning restore 612, 618
        }
    }
}
