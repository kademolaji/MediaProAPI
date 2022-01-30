using Nager.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Domain.Helpers
{
    public static class DateTimeExtensions
    {
		public static DateTime AddWorkdays(this DateTime originalDate, int workDays, CountryCode countryCode)
		{
			DateTime tmpDate = originalDate;
			while (workDays > 0)
			{
				tmpDate = tmpDate.AddDays(1);
				if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
					tmpDate.DayOfWeek > DayOfWeek.Sunday &&
					!tmpDate.IsHoliday(countryCode))
				{
					workDays--;
				}
			}

			return tmpDate;
		}

		public static bool IsHoliday(this DateTime originalDate, CountryCode countryCode)
		{
			return DateSystem.IsPublicHoliday(originalDate, countryCode);
		}
	}
}
