using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace ClinicaApp.Modelos
{
	public class Horarios
	{
		public int IdHorario { get; set; }
		public int IdMedico { get; set; }
		public DayOfWeek Dia { get; set; }
		public TimeSpan HoraInicio { get; set; }
		public TimeSpan HoraFin { get; set; }

		// Relación de navegación con la clase Medico
		public Medico Medico { get; set; }
	}
}
