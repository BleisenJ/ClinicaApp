using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaApp.Modelos
{
	public class Cita
	{
		public int IdCita { get; set; }
		public int IdMedico { get; set; }
		public int IdPaciente { get; set; }
		public DateTime FechaHora { get; set; }
		public string TipoConsulta { get; set; }


		// Relación con Medico
		public Medico Medico { get; set; }

		// Relación con Paciente
		public Paciente Paciente { get; set; }
	}
}
