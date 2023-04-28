﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WorkSchedule.Infrastructure.Persistence;

#nullable disable

namespace WorkSchedule.Infrastructure.Migrations
{
    [DbContext(typeof(ScheduleContext))]
    [Migration("20230428144712_Init2")]
    partial class Init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WorkSchedule.Domain.Entities.Shift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("text");

                    b.Property<string>("EndHour")
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("StartHour")
                        .HasColumnType("text");

                    b.Property<Guid?>("WorkingDayId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkingDayId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("WorkSchedule.Domain.Entities.WorkingDay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CloseHour")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATE");

                    b.Property<string>("OpenHour")
                        .HasColumnType("text");

                    b.Property<Guid?>("WorkingMonthId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkingMonthId");

                    b.ToTable("WorkingDays");
                });

            modelBuilder.Entity("WorkSchedule.Domain.Entities.WorkingMonth", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("MonthEndDate")
                        .HasColumnType("DATE");

                    b.Property<string>("MonthName")
                        .HasColumnType("text");

                    b.Property<DateTime>("MonthStartDate")
                        .HasColumnType("DATE");

                    b.HasKey("Id");

                    b.ToTable("WorkingMonths");
                });

            modelBuilder.Entity("WorkSchedule.Domain.Entities.Shift", b =>
                {
                    b.HasOne("WorkSchedule.Domain.Entities.WorkingDay", null)
                        .WithMany("Shifts")
                        .HasForeignKey("WorkingDayId");
                });

            modelBuilder.Entity("WorkSchedule.Domain.Entities.WorkingDay", b =>
                {
                    b.HasOne("WorkSchedule.Domain.Entities.WorkingMonth", null)
                        .WithMany("WorkingDays")
                        .HasForeignKey("WorkingMonthId");
                });

            modelBuilder.Entity("WorkSchedule.Domain.Entities.WorkingDay", b =>
                {
                    b.Navigation("Shifts");
                });

            modelBuilder.Entity("WorkSchedule.Domain.Entities.WorkingMonth", b =>
                {
                    b.Navigation("WorkingDays");
                });
#pragma warning restore 612, 618
        }
    }
}
