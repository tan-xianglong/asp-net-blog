﻿// <auto-generated />
using System;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220522071230_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            CreateDate = new DateTime(2022, 5, 22, 15, 12, 29, 854, DateTimeKind.Local).AddTicks(3218),
                            Email = "john@mail.com",
                            Message = "Please contact me.",
                            Name = "John Piper",
                            PhoneNumber = "12345"
                        });
                });

            modelBuilder.Entity("Blog.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subtitle")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("PostId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            Content = "Loren Ipsum",
                            CreateDate = new DateTime(2022, 5, 22, 15, 12, 29, 850, DateTimeKind.Local).AddTicks(6012),
                            Subtitle = "Problems look mighty small from 150 miles up",
                            Title = "Man must explore, and this is exploration at its greatest"
                        },
                        new
                        {
                            PostId = 2,
                            Content = "Loren Ipsum",
                            CreateDate = new DateTime(2022, 5, 22, 15, 12, 29, 854, DateTimeKind.Local).AddTicks(711),
                            Title = "I believe every human has a finite number of heartbeats. I don't intend to waste any of mine."
                        },
                        new
                        {
                            PostId = 3,
                            Content = "Loren Ipsum",
                            CreateDate = new DateTime(2022, 5, 22, 15, 12, 29, 854, DateTimeKind.Local).AddTicks(875),
                            Subtitle = "We predict too much for the next year and yet far too little for the next ten.",
                            Title = "Science has not yet mastered prophecy"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}