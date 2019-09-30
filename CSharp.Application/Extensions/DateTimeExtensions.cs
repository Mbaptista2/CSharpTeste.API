using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Application.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool FimDeSemana(this DateTime data)
        {
            return new[] { DayOfWeek.Sunday, DayOfWeek.Saturday }.Contains(data.DayOfWeek);
        }
    }
}
