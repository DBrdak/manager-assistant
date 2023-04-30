using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Domain.Entities;

namespace WorkSchedule.Infrastructure.Persistence
{
    public class ScheduleContext : DbContext
    {
        DbSet<Shift> Shifts { get; set; }
        DbSet<WorkingDay> WorkingDays { get; set; }
        DbSet<WorkingMonth> WorkingMonths { get; set; }

        public ScheduleContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Shift>()
            //    .Property(s => s.Start).HasColumnType("TIMESTAMP");

            //modelBuilder.Entity<Shift>()
            //    .Property(s => s.End).HasColumnType("TIMESTAMP");

            modelBuilder.Entity<WorkingDay>()
                .Property(wd => wd.Date).HasColumnType("DATE");

            modelBuilder.Entity<WorkingDay>()
                .HasMany(wd => wd.Shifts)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<WorkingDay>()
            //    .Property(wd => wd.DayOpen).HasColumnType("TIMESTAMP");

            //modelBuilder.Entity<WorkingDay>()
            //    .Property(wd => wd.DayClose).HasColumnType("TIMESTAMP");

            modelBuilder.Entity<WorkingMonth>()
                .Property(wm => wm.MonthStartDate).HasColumnType("DATE");

            modelBuilder.Entity<WorkingMonth>()
                .Property(wm => wm.MonthEndDate).HasColumnType("DATE");

            modelBuilder.Entity<WorkingMonth>()
                .HasMany(wm => wm.WorkingDays)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
