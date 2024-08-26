﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using heroAPI.Data;

#nullable disable

namespace heroAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240825113014_heroes")]
    partial class heroes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("heroAPI.Models.Hero", b =>
                {
                    b.Property<int>("HeroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HeroId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("HeroId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Hero");
                });

            modelBuilder.Entity("heroAPI.Models.HeroPower", b =>
                {
                    b.Property<int>("HeroId")
                        .HasColumnType("int");

                    b.Property<int>("PowerId")
                        .HasColumnType("int");

                    b.HasKey("HeroId", "PowerId");

                    b.HasIndex("PowerId");

                    b.ToTable("HeroPowers");
                });

            modelBuilder.Entity("heroAPI.Models.Power", b =>
                {
                    b.Property<int>("PowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PowerId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PowerId");

                    b.ToTable("Power");
                });

            modelBuilder.Entity("heroAPI.Models.School", b =>
                {
                    b.Property<int>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SchoolId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolId");

                    b.ToTable("School");
                });

            modelBuilder.Entity("heroAPI.Models.Hero", b =>
                {
                    b.HasOne("heroAPI.Models.School", "School")
                        .WithMany("Students")
                        .HasForeignKey("SchoolId");

                    b.Navigation("School");
                });

            modelBuilder.Entity("heroAPI.Models.HeroPower", b =>
                {
                    b.HasOne("heroAPI.Models.Hero", "Hero")
                        .WithMany("HeroPowers")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("heroAPI.Models.Power", "Power")
                        .WithMany("HeroPowers")
                        .HasForeignKey("PowerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Hero");

                    b.Navigation("Power");
                });

            modelBuilder.Entity("heroAPI.Models.Hero", b =>
                {
                    b.Navigation("HeroPowers");
                });

            modelBuilder.Entity("heroAPI.Models.Power", b =>
                {
                    b.Navigation("HeroPowers");
                });

            modelBuilder.Entity("heroAPI.Models.School", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
