﻿// <auto-generated />
using System;
using System.Collections.Generic;
using BikeServiceAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BikeServiceAPI.Migrations
{
    [DbContext(typeof(BikeServiceContext))]
    [Migration("20230607085944_AddUserRoles")]
    partial class AddUserRoles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.Bike", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("BikeType")
                        .HasColumnType("integer");

                    b.Property<int>("FrameSize")
                        .HasColumnType("integer");

                    b.Property<bool>("Insured")
                        .HasColumnType("boolean");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WheelSize")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Bikes");
                });

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.BikeNews", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PictureLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BikeNews");
                });

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.Colleague", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Introduction")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<int>>("Roles")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Colleagues");
                });

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.Part", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<long?>("TransactionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.ServiceEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("BikeId")
                        .HasColumnType("bigint");

                    b.Property<long>("ColleagueId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BikeId");

                    b.HasIndex("ColleagueId");

                    b.ToTable("ServiceEvents");
                });

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.Tour", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Difficulty")
                        .HasColumnType("integer");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double precision");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Introduction")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Premium")
                        .HasColumnType("boolean");

                    b.Property<List<int>>("Roles")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TourUser", b =>
                {
                    b.Property<long>("ParticipantsId")
                        .HasColumnType("bigint");

                    b.Property<long>("ToursId")
                        .HasColumnType("bigint");

                    b.HasKey("ParticipantsId", "ToursId");

                    b.HasIndex("ToursId");

                    b.ToTable("TourUser");
                });

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.Bike", b =>
                {
                    b.HasOne("BikeServiceAPI.Models.Entities.User", null)
                        .WithMany("Bikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.Part", b =>
                {
                    b.HasOne("BikeServiceAPI.Models.Entities.Transaction", null)
                        .WithMany("PurchasedItems")
                        .HasForeignKey("TransactionId");
                });

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.ServiceEvent", b =>
                {
                    b.HasOne("BikeServiceAPI.Models.Entities.Bike", null)
                        .WithMany("ServiceHistory")
                        .HasForeignKey("BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeServiceAPI.Models.Entities.Colleague", null)
                        .WithMany("ServiceEvents")
                        .HasForeignKey("ColleagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.Transaction", b =>
                {
                    b.HasOne("BikeServiceAPI.Models.Entities.User", "User")
                        .WithMany("TransactionHistory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TourUser", b =>
                {
                    b.HasOne("BikeServiceAPI.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeServiceAPI.Models.Entities.Tour", null)
                        .WithMany()
                        .HasForeignKey("ToursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.Bike", b =>
                {
                    b.Navigation("ServiceHistory");
                });

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.Colleague", b =>
                {
                    b.Navigation("ServiceEvents");
                });

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.Transaction", b =>
                {
                    b.Navigation("PurchasedItems");
                });

            modelBuilder.Entity("BikeServiceAPI.Models.Entities.User", b =>
                {
                    b.Navigation("Bikes");

                    b.Navigation("TransactionHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
