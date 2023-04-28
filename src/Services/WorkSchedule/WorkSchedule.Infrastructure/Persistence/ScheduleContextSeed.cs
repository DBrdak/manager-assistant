using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Entities;

namespace WorkSchedule.Infrastructure.Persistence;

public static class ScheduleContextSeed
{
    public static void Seed(this ScheduleContext context)
    {
        if(!context.Set<Shift>().Any() &&
           !context.Set<WorkingDay>().Any() &&
           !context.Set<WorkingMonth>().Any())
        {
            var workingDays = new List<WorkingDay>();
            List<Shift> shifts = null;
            for (int i = 1; i <= 20; i++)
            {
                shifts = new List<Shift>();
                var list = new List<Shift>();
                list.Add(new Shift()
                {
                    EmployeeName = "Adam",
                    Note = "Clean the floors",
                    StartHour = "09:00",
                    EndHour = "12:00"
                });
                list.Add(new Shift()
                {
                    EmployeeName = "Emily",
                    Note = "Check inventory",
                    StartHour = "12:00",
                    EndHour = "15:00"
                });
                list.Add(new Shift()
                {
                    EmployeeName = "David",
                    Note = "Handle customer service",
                    StartHour = "15:00",
                    EndHour = "18:00"
                });
                shifts.AddRange(list);
                var date = new DateTime(2023, 4, i);
                var shiftsForDay = new List<Shift>(shifts);

                var workingDay = new WorkingDay()
                {
                    Date = date,
                    Shifts = shiftsForDay,
                    OpenHour = "09:00",
                    CloseHour = "18:00"
                };

                workingDays.Add(workingDay);
            }

            var workingMonth = new WorkingMonth()
            {   
                MonthStartDate = new DateTime(2023, 4, 1),
                MonthEndDate = new DateTime(2023, 4, 30),
                MonthName = "April",
                WorkingDays = workingDays,
                IsApproved = true
            };

            context.Add(workingMonth);
            context.AddRange(workingDays);
            context.AddRange(shifts);
            context.SaveChanges();
        }
    }
}