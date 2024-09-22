using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaApp.DTOs
{
	public class MedicoDTO
	{
		public int IdMedico { get; set; }
		public string Nombre { get; set; }
		public string Especialidad { get; set; }
		public List<HorarioDTO> Horarios { get; set; } = new List<HorarioDTO>();
	}
}

