using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaApp.DTOs
{
	public class MedicamentoDTO
	{
		public int IdMedicamento { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public int CantidadDisponible { get; set; }
		public int CantidadMinima { get; set; }
	}
}
