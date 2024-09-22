using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace ClinicaApp.Utilidades
{
	public class DateTimeToTimeSpanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is DateTime dateTime)
			{
				return dateTime.TimeOfDay;
			}
			return TimeSpan.Zero;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is TimeSpan timeSpan)
			{
				return DateTime.Today.Add(timeSpan);
			}
			return DateTime.Today;
		}
	}
}