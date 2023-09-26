﻿// <auto-generated />
using Lift.Buddy.Core.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lift.Buddy.Core.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230926201327_AddedWorkplanReview")]
    partial class AddedWorkplanReview
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("Lift.Buddy.Core.DB.Models.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Answers")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsTrainer")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Questions")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Lift.Buddy.Core.DB.Models.UserAssociation", b =>
                {
                    b.Property<string>("TrainerUsername")
                        .HasColumnType("TEXT");

                    b.Property<string>("AthleteUsername")
                        .HasColumnType("TEXT");

                    b.HasKey("TrainerUsername", "AthleteUsername");

                    b.HasIndex("AthleteUsername")
                        .IsUnique();

                    b.HasIndex("TrainerUsername")
                        .IsUnique();

                    b.ToTable("UserAssociation");
                });

            modelBuilder.Entity("Lift.Buddy.Core.DB.Models.UserPR", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "username");

                    b.Property<string>("PersonalRecords")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "personalRecords");

                    b.HasKey("Username");

                    b.ToTable("UserPRs");
                });

            modelBuilder.Entity("Lift.Buddy.Core.DB.Models.WorkoutAssignment", b =>
                {
                    b.Property<int>("WorkoutId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WorkoutUser")
                        .HasColumnType("TEXT");

                    b.HasKey("WorkoutId", "WorkoutUser");

                    b.HasIndex("WorkoutUser");

                    b.ToTable("WorkoutAssignments");
                });

            modelBuilder.Entity("Lift.Buddy.Core.DB.Models.WorkoutPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "createdBy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<int>("ReviewAverage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0)
                        .HasAnnotation("Relational:JsonPropertyName", "reviewAverage");

                    b.Property<int>("ReviewersAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0)
                        .HasAnnotation("Relational:JsonPropertyName", "reviewersAmount");

                    b.Property<string>("WorkoutDays")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "workoutDays");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("WorkoutSchedules");
                });

            modelBuilder.Entity("Lift.Buddy.Core.DB.Models.UserAssociation", b =>
                {
                    b.HasOne("Lift.Buddy.Core.DB.Models.User", "Athlete")
                        .WithOne()
                        .HasForeignKey("Lift.Buddy.Core.DB.Models.UserAssociation", "AthleteUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lift.Buddy.Core.DB.Models.User", "Trainer")
                        .WithOne()
                        .HasForeignKey("Lift.Buddy.Core.DB.Models.UserAssociation", "TrainerUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Athlete");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Lift.Buddy.Core.DB.Models.UserPR", b =>
                {
                    b.HasOne("Lift.Buddy.Core.DB.Models.User", "User")
                        .WithOne("UserPR")
                        .HasForeignKey("Lift.Buddy.Core.DB.Models.UserPR", "Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lift.Buddy.Core.DB.Models.WorkoutAssignment", b =>
                {
                    b.HasOne("Lift.Buddy.Core.DB.Models.WorkoutPlan", "WorkoutSchedule")
                        .WithMany("WorkoutAssignments")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lift.Buddy.Core.DB.Models.User", "User")
                        .WithMany("WorkoutAssignments")
                        .HasForeignKey("WorkoutUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("WorkoutSchedule");
                });

            modelBuilder.Entity("Lift.Buddy.Core.DB.Models.WorkoutPlan", b =>
                {
                    b.HasOne("Lift.Buddy.Core.DB.Models.User", "Creator")
                        .WithMany("WorkoutSchedules")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Lift.Buddy.Core.DB.Models.User", b =>
                {
                    b.Navigation("UserPR")
                        .IsRequired();

                    b.Navigation("WorkoutAssignments");

                    b.Navigation("WorkoutSchedules");
                });

            modelBuilder.Entity("Lift.Buddy.Core.DB.Models.WorkoutPlan", b =>
                {
                    b.Navigation("WorkoutAssignments");
                });
#pragma warning restore 612, 618
        }
    }
}
