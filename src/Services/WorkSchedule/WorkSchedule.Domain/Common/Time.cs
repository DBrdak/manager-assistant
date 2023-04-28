using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace WorkSchedule.Domain.Common
{
    public class Time
    {
        public int Hour { get; private set; }
        public int Minutes { get; private set; }

        [RegularExpression("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$")]
        public string Value
        {
            get => $"{Hour}:{Minutes}";
            set
            {
                var s = value.Split(':');
                Hour = int.Parse(s[0]);
                Minutes = int.Parse(s[1]);
            }
        }

        public Time(string time)
        {
            Value = time;
        }

        public static bool operator > (Time left, Time right)
        {
            switch (left.Hour == right.Hour)
            {
                case true:
                    return left.Minutes > right.Minutes;
                case false:
                    return left.Hour > right.Hour;
            }
        }

        public static bool operator <(Time left, Time right)
        {
            switch (left.Hour == right.Hour)
            {
                case true:
                    return left.Minutes < right.Minutes;
                case false:
                    return left.Hour < right.Hour;
            }
        }
    }
}
