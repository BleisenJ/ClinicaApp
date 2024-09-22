using System;
using System.Globalization;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;

namespace ClinicaApp.Converters
{
	public class EstadoToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// Dependiendo del estado (por ejemplo, activo/inactivo) asigna un color
			if (value != null && value is bool estado)
			{
				return estado ? Colors.Green : Colors.Red;
			}
			return Colors.Transparent;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
