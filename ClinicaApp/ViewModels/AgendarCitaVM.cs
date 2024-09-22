using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ClinicaApp.Modelos;
using ClinicaApp.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp.ViewModels
{
	public partial class AgendarCitaVM : ObservableObject
	{
		private readonly ClinicaDbContext _context;

		[ObservableProperty]
		private ObservableCollection<Medico> medicos;

		[ObservableProperty]
		private ObservableCollection<Horarios> horarios;

		[ObservableProperty]
		private DateTime fechaSeleccionada;

		[ObservableProperty]
		private TimeSpan horaSeleccionada;

		[ObservableProperty]
		private Medico medicoSeleccionado;

		[ObservableProperty]
		private string tipoConsulta;

		[ObservableProperty]
		private string mensajeConfirmacion;

		public AgendarCitaVM(ClinicaDbContext context)
		{
			_context = context;
			_ = CargarMedicos();
		}

		// Método para cargar la lista de médicos
		private async Task CargarMedicos()
		{
			Medicos = new ObservableCollection<Medico>(await _context.Medicos.ToListAsync());
		}

		[RelayCommand]
		public async Task AgendarCita()
		{
			if (FechaSeleccionada == default || HoraSeleccionada == default || MedicoSeleccionado == null || string.IsNullOrWhiteSpace(TipoConsulta))
			{
				MensajeConfirmacion = "Por favor, complete todos los campos.";
				return;
			}

			var nuevaCita = new Cita
			{
				FechaHora = FechaSeleccionada.Add(HoraSeleccionada),
				Medico = MedicoSeleccionado,
				TipoConsulta = TipoConsulta,
				IdPaciente = 1, // Aquí se debe obtener el IdPaciente actual (modificar según lógica)
			};

			_context.Citas.Add(nuevaCita);
			await _context.SaveChangesAsync();

			MensajeConfirmacion = $"Cita agendada con éxito para el {FechaSeleccionada:d} a las {HoraSeleccionada}.";
		}
	}
}
