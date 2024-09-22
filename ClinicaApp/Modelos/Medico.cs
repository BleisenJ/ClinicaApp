using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaApp.Modelos
{
	public class Medico
	{
		public int IdMedico { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Especialidad { get; set; }
		public string NumeroCedula { get; set; }

		// Relación con Citas
		public ICollection<Cita> Citas { get; set; }

		// Relación con Horarios
		public ICollection<Horarios> Horarios { get; set; }
	}
}

