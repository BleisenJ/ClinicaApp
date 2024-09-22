using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaApp.DTOs
{
	public class HorarioDTO
	{
		public int IdHorario { get; set; }
		public DayOfWeek Dia { get; set; }
		public TimeSpan HoraInicio { get; set; }
		public TimeSpan HoraFin { get; set; }
		public string MedicoNombre { get; set; } // Información del médico para mostrar en la vista
	}
}

