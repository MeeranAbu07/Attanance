﻿// <auto-generated />
using System;
using Attanance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Attanance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Attanance.Models.Attanances", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Attanance")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AttananceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LeaveReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserBasicDetailsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserBasicDetailsId");

                    b.ToTable("attanances");
                });

            modelBuilder.Entity("Attanance.Models.TaskDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ModuleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TaskCompleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TaskStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserBasicDetailsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserBasicDetailsId");

                    b.ToTable("TaskDetails");
                });

            modelBuilder.Entity("Attanance.Models.UserBasicDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Doj")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserBasics");
                });

            modelBuilder.Entity("Attanance.Models.Attanances", b =>
                {
                    b.HasOne("Attanance.Models.UserBasicDetails", "basicDetails")
                        .WithMany()
                        .HasForeignKey("UserBasicDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("basicDetails");
                });

            modelBuilder.Entity("Attanance.Models.TaskDetails", b =>
                {
                    b.HasOne("Attanance.Models.UserBasicDetails", "basicDetails")
                        .WithMany()
                        .HasForeignKey("UserBasicDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("basicDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
