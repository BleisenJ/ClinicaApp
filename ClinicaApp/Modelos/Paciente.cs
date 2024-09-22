using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaApp.Modelos
{
	public class Paciente
	{
		public int IdPaciente { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Direccion { get; set; }
		public string Correo { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public string Cedula { get; set; }
		public string ContactoEmergencia { get; set; }
		public string Posicion { get; set; } // Estudiante, Profesor, Administrativo, etc.

		// Relación con Citas
		public ICollection<Cita> Citas { get; set; }
	}
}