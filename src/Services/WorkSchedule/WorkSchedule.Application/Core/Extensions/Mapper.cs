using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Common;

namespace WorkSchedule.Application.Core.Extensions
{
    public static class Mapper
    {
        public static T Replace<T>(this T initial, T final) where T : class
        {
            var finalPropsValues = final.GetType().GetProperties().Select(pi => pi.GetValue(final)).ToArray();

            for (int i = 0; i < finalPropsValues.Length; i++)
            {
                initial.GetType().GetProperties()[i].SetValue(initial, finalPropsValues[i]);
            }

            return initial;
        }
    }
}
