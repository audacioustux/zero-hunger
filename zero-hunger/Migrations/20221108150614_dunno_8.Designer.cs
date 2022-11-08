﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using zero_hunger;

#nullable disable

namespace zero_hunger.Migrations
{
    [DbContext(typeof(PostgreSqlDBContext))]
    [Migration("20221108150614_dunno_8")]
    partial class dunno_8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("zero_hunger.Models.CollectRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AssignedEmployeeId")
                        .HasColumnType("integer");

                    b.Property<int>("ByRestaurantId")
                        .HasColumnType("integer");

                    b.Property<int>("CanPreserveForMinutes")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CollectedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCollected")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AssignedEmployeeId");

                    b.HasIndex("ByRestaurantId");

                    b.ToTable("CollectRequest");
                });

            modelBuilder.Entity("zero_hunger.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ManagedByUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ManagedByUserId");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("zero_hunger.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsEmployee")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("zero_hunger.Models.CollectRequest", b =>
                {
                    b.HasOne("zero_hunger.Models.User", "AssignedEmployee")
                        .WithMany()
                        .HasForeignKey("AssignedEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("zero_hunger.Models.Restaurant", "ByRestaurant")
                        .WithMany()
                        .HasForeignKey("ByRestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedEmployee");

                    b.Navigation("ByRestaurant");
                });

            modelBuilder.Entity("zero_hunger.Models.Restaurant", b =>
                {
                    b.HasOne("zero_hunger.Models.User", "ManagedByUser")
                        .WithMany()
                        .HasForeignKey("ManagedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ManagedByUser");
                });
#pragma warning restore 612, 618
        }
    }
}