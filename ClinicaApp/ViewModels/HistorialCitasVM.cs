using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ClinicaApp.Modelos;
using ClinicaApp.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp.ViewModels
{
	public partial class HistorialCitasVM : ObservableObject
	{
		private readonly ClinicaDbContext _context;

		[ObservableProperty]
		private ObservableCollection<Cita> citasPasadas;

		[ObservableProperty]
		private ObservableCollection<Cita> citasFuturas;

		[ObservableProperty]
		private bool loadingEsVisible = false;

		// Constructor público que recibe el DbContext
		public HistorialCitasVM(ClinicaDbContext context)
		{
			_context = context;
			CargarCitas();
		}

		// Método para cargar las citas del paciente
		private async Task CargarCitas()
		{
			LoadingEsVisible = true;

			var citasDb = await _context.Citas
				.Include(c => c.Medico) // Aseguramos que cargue el médico asociado
				.Where(c => c.IdPaciente == ObtenerIdPaciente()) // Método para obtener el ID del paciente actual
				.ToListAsync();

			var citasPasadasTemp = new ObservableCollection<Cita>();
			var citasFuturasTemp = new ObservableCollection<Cita>();

			foreach (var cita in citasDb)
			{
				if (cita.FechaHora < DateTime.Now)
				{
					citasPasadasTemp.Add(cita);
				}
				else
				{
					citasFuturasTemp.Add(cita);
				}
			}

			CitasPasadas = citasPasadasTemp;
			CitasFuturas = citasFuturasTemp;

			LoadingEsVisible = false;
		}

		private int ObtenerIdPaciente()
		{
			// Implementar la lógica para obtener el ID del paciente actual
			return 1; // Este es un valor de ejemplo
		}
	}
}
