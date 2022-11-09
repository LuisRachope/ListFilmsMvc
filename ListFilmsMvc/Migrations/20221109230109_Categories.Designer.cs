﻿// <auto-generated />
using System;
using ListFilmsMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ListFilmsMvc.Migrations
{
    [DbContext(typeof(ListFilmsMvcContext))]
    [Migration("20221109230109_Categories")]
    partial class Categories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ListFilmsMvc.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ListFilmsMvc.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("ListFilmsMvc.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Director");

                    b.Property<int>("GenreId");

                    b.Property<double>("Rating");

                    b.Property<int>("RealeseYear");

                    b.Property<string>("Title");

                    b.Property<int?>("TypeCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("TypeCategoryId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("ListFilmsMvc.Models.Movie", b =>
                {
                    b.HasOne("ListFilmsMvc.Models.Genre", "TypeGenre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ListFilmsMvc.Models.Category", "TypeCategory")
                        .WithMany()
                        .HasForeignKey("TypeCategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}