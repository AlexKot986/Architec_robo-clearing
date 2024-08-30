﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RoboClearingApi.Contexts;

#nullable disable

namespace RoboClearingApi.Migrations
{
    [DbContext(typeof(RoboClearingPostgreSqlDBContext))]
    partial class RoboClearingPostgreSqlDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RoboClearingApi.Models.Domain.RoboStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("robostatus_pkey");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("robostatuses", (string)null);
                });

            modelBuilder.Entity("RoboClearingApi.Models.Domain.Robot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Model")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("status_id");

                    b.HasKey("Id")
                        .HasName("robot_pkey");

                    b.HasIndex("StatusId");

                    b.ToTable("robots", (string)null);
                });

            modelBuilder.Entity("RoboClearingApi.Models.Domain.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("room_pkey");

                    b.ToTable("rooms", (string)null);
                });

            modelBuilder.Entity("RoboClearingApi.Models.Domain.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndClearing")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_clearing");

                    b.Property<int>("RobotId")
                        .HasColumnType("integer");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartClearing")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_clearing");

                    b.Property<int>("TypeOfClearingId")
                        .HasMaxLength(20)
                        .HasColumnType("integer")
                        .HasColumnName("clearing_id");

                    b.Property<int>("WeekDayId")
                        .HasColumnType("integer")
                        .HasColumnName("week_day_id");

                    b.HasKey("Id")
                        .HasName("schadule_pkey");

                    b.HasIndex("RobotId");

                    b.HasIndex("RoomId");

                    b.HasIndex("TypeOfClearingId");

                    b.ToTable("schedules", (string)null);
                });

            modelBuilder.Entity("RoboClearingApi.Models.Domain.TypeOfClearing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("type_pkey");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("types", (string)null);
                });

            modelBuilder.Entity("RoboClearingApi.Models.Domain.WeekDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("day");

                    b.HasKey("Id")
                        .HasName("week_day_pkey");

                    b.HasIndex("Day")
                        .IsUnique();

                    b.ToTable("week_days", (string)null);
                });

            modelBuilder.Entity("ScheduleWeekDay", b =>
                {
                    b.Property<int>("SchedulesId")
                        .HasColumnType("integer");

                    b.Property<int>("WeekDayListId")
                        .HasColumnType("integer");

                    b.HasKey("SchedulesId", "WeekDayListId");

                    b.HasIndex("WeekDayListId");

                    b.ToTable("ScheduleWeekDay");
                });

            modelBuilder.Entity("RoboClearingApi.Models.Domain.Robot", b =>
                {
                    b.HasOne("RoboClearingApi.Models.Domain.RoboStatus", "Status")
                        .WithMany("Robots")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("RoboClearingApi.Models.Domain.Schedule", b =>
                {
                    b.HasOne("RoboClearingApi.Models.Domain.Robot", "Robot")
                        .WithMany()
                        .HasForeignKey("RobotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoboClearingApi.Models.Domain.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoboClearingApi.Models.Domain.TypeOfClearing", "TypeOfClearing")
                        .WithMany()
                        .HasForeignKey("TypeOfClearingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Robot");

                    b.Navigation("Room");

                    b.Navigation("TypeOfClearing");
                });

            modelBuilder.Entity("ScheduleWeekDay", b =>
                {
                    b.HasOne("RoboClearingApi.Models.Domain.Schedule", null)
                        .WithMany()
                        .HasForeignKey("SchedulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoboClearingApi.Models.Domain.WeekDay", null)
                        .WithMany()
                        .HasForeignKey("WeekDayListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoboClearingApi.Models.Domain.RoboStatus", b =>
                {
                    b.Navigation("Robots");
                });
#pragma warning restore 612, 618
        }
    }
}
