﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QandQ.Data;

#nullable disable

namespace QandQ.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QandQ.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Adult")
                        .HasColumnType("boolean");

                    b.Property<string>("BackdropPath")
                        .HasColumnType("text");

                    b.Property<List<int>>("GenreIds")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<string>("OriginalLanguage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OriginalTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Popularity")
                        .HasColumnType("double precision");

                    b.Property<string>("PosterPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Video")
                        .HasColumnType("boolean");

                    b.Property<double>("VoteAverage")
                        .HasColumnType("double precision");

                    b.Property<int>("VoteCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("QandQ.Entities.MovieRateAndNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rate")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("MovieRateAndNote");
                });

            modelBuilder.Entity("QandQ.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QandQ.Entities.MovieRateAndNote", b =>
                {
                    b.HasOne("QandQ.Entities.Movie", "Movie")
                        .WithMany("MovieRateAndNote")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QandQ.Entities.User", "User")
                        .WithMany("MovieRateAndNote")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QandQ.Entities.Movie", b =>
                {
                    b.Navigation("MovieRateAndNote");
                });

            modelBuilder.Entity("QandQ.Entities.User", b =>
                {
                    b.Navigation("MovieRateAndNote");
                });
#pragma warning restore 612, 618
        }
    }
}