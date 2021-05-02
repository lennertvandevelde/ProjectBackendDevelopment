﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Outlaws.API.Data;

namespace Outlaws.API.Migrations
{
    [DbContext(typeof(OutlawContext))]
    [Migration("20210502101140_NoCauseAdded")]
    partial class NoCauseAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Outlaws.API.Models.DeathCause", b =>
                {
                    b.Property<Guid>("DeathCauseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeathUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeathCauseId");

                    b.ToTable("DeathCauses");

                    b.HasData(
                        new
                        {
                            DeathCauseId = new Guid("b82f1cde-d0bc-46f8-bf90-f8092349a861"),
                            DeathUri = "http://dbpedia.org/resource/Gunshot_wounds",
                            Description = "Gunshot wound"
                        },
                        new
                        {
                            DeathCauseId = new Guid("0502be48-d9c7-46b2-80bc-726fbc2f0b6c"),
                            Description = "None"
                        });
                });

            modelBuilder.Entity("Outlaws.API.Models.Gang", b =>
                {
                    b.Property<Guid>("GangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GangName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GangUri")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GangId");

                    b.ToTable("Gangs");

                    b.HasData(
                        new
                        {
                            GangId = new Guid("48be1c96-ac9e-4dc7-978e-0924c8d92a87"),
                            GangName = "Butch Cassidy's Wild Bunch",
                            GangUri = "http://dbpedia.org/resource/Butch_Cassidy's_Wild_Bunch"
                        },
                        new
                        {
                            GangId = new Guid("f2a2d10b-dfb3-46c3-95e5-08458ea5114c"),
                            GangName = "James–Younger Gang",
                            GangUri = "https://dbpedia.org/resource/James-Younger_Gang"
                        });
                });

            modelBuilder.Entity("Outlaws.API.Models.GangOutlaw", b =>
                {
                    b.Property<Guid>("GangId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OutlawId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GangId", "OutlawId");

                    b.HasIndex("OutlawId");

                    b.ToTable("GangOutlaw");
                });

            modelBuilder.Entity("Outlaws.API.Models.Outlaw", b =>
                {
                    b.Property<Guid>("OutlawId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BirthDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DeathCauseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeathDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OutlawUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OutlawId");

                    b.HasIndex("DeathCauseId");

                    b.ToTable("Outlaws");
                });

            modelBuilder.Entity("Outlaws.API.Models.GangOutlaw", b =>
                {
                    b.HasOne("Outlaws.API.Models.Gang", "Gang")
                        .WithMany("GangOutlaws")
                        .HasForeignKey("GangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Outlaws.API.Models.Outlaw", "Outlaw")
                        .WithMany("GangOutlaws")
                        .HasForeignKey("OutlawId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gang");

                    b.Navigation("Outlaw");
                });

            modelBuilder.Entity("Outlaws.API.Models.Outlaw", b =>
                {
                    b.HasOne("Outlaws.API.Models.DeathCause", "DeathCause")
                        .WithMany("Outlaws")
                        .HasForeignKey("DeathCauseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeathCause");
                });

            modelBuilder.Entity("Outlaws.API.Models.DeathCause", b =>
                {
                    b.Navigation("Outlaws");
                });

            modelBuilder.Entity("Outlaws.API.Models.Gang", b =>
                {
                    b.Navigation("GangOutlaws");
                });

            modelBuilder.Entity("Outlaws.API.Models.Outlaw", b =>
                {
                    b.Navigation("GangOutlaws");
                });
#pragma warning restore 612, 618
        }
    }
}