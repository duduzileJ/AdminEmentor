﻿// <auto-generated />
using System;
using AdminEmentor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdminEmentor.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20221003094644_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AdminEmentor.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TutorID")
                        .HasColumnType("int");

                    b.HasKey("DepartmentID");

                    b.HasIndex("TutorID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("AdminEmentor.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentID"), 1L, 1);

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("StudentID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("AdminEmentor.Models.Schedule", b =>
                {
                    b.Property<int>("TutorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TutorID"), 1L, 1);

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TutorID1")
                        .HasColumnType("int");

                    b.Property<DateTime>("classDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TutorID");

                    b.HasIndex("TutorID1");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("AdminEmentor.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"), 1L, 1);

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StudentID");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("AdminEmentor.Models.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Subject", (string)null);
                });

            modelBuilder.Entity("AdminEmentor.Models.Tutor", b =>
                {
                    b.Property<int>("TutorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TutorID"), 1L, 1);

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TutorID");

                    b.ToTable("Tutor", (string)null);
                });

            modelBuilder.Entity("SubjectTutor", b =>
                {
                    b.Property<int>("SubjectsSubjectID")
                        .HasColumnType("int");

                    b.Property<int>("TutorsTutorID")
                        .HasColumnType("int");

                    b.HasKey("SubjectsSubjectID", "TutorsTutorID");

                    b.HasIndex("TutorsTutorID");

                    b.ToTable("SubjectTutor");
                });

            modelBuilder.Entity("AdminEmentor.Models.Department", b =>
                {
                    b.HasOne("AdminEmentor.Models.Tutor", "Administrator")
                        .WithMany()
                        .HasForeignKey("TutorID");

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("AdminEmentor.Models.Enrollment", b =>
                {
                    b.HasOne("AdminEmentor.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdminEmentor.Models.Subject", "Subject")
                        .WithMany("Enrollments")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("AdminEmentor.Models.Schedule", b =>
                {
                    b.HasOne("AdminEmentor.Models.Tutor", "Tutor")
                        .WithMany("Schedules")
                        .HasForeignKey("TutorID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("AdminEmentor.Models.Subject", b =>
                {
                    b.HasOne("AdminEmentor.Models.Department", "Department")
                        .WithMany("Subjects")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SubjectTutor", b =>
                {
                    b.HasOne("AdminEmentor.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsSubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdminEmentor.Models.Tutor", null)
                        .WithMany()
                        .HasForeignKey("TutorsTutorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdminEmentor.Models.Department", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("AdminEmentor.Models.Student", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("AdminEmentor.Models.Subject", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("AdminEmentor.Models.Tutor", b =>
                {
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
