using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ClinicaApp.Modelos;
using ClinicaApp.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp.ViewModels
{
	public partial class MedicoVM : ObservableObject
	{
		private readonly ClinicaDbContext _context;

		[ObservableProperty]
		private ObservableCollection<Medico> listaMedicos;

		[ObservableProperty]
		private Medico medicoSeleccionado;

		[ObservableProperty]
		private ObservableCollection<Horarios> horarios;

		[ObservableProperty]
		private DayOfWeek diaSeleccionado;

		[ObservableProperty]
		private TimeSpan horaInicio;

		[ObservableProperty]
		private TimeSpan horaFin;

		// Constructor sin parámetros
		public MedicoVM() { }

		public MedicoVM(ClinicaDbContext context)
		{
			_context = context;
			CargarMedicos();
		}

		private async Task CargarMedicos()
		{
			ListaMedicos = new ObservableCollection<Medico>(await _context.Medicos.Include(m => m.Horarios).ToListAsync());
		}

		[RelayCommand]
		public async Task AgregarMedico()
		{
			if (string.IsNullOrWhiteSpace(medicoSeleccionado?.Nombre) || string.IsNullOrWhiteSpace(medicoSeleccionado?.Especialidad))
				return;

			var nuevoMedico = new Medico
			{
				Nombre = medicoSeleccionado.Nombre,
				Especialidad = medicoSeleccionado.Especialidad
			};
			_context.Medicos.Add(nuevoMedico);
			await _context.SaveChangesAsync();
			ListaMedicos.Add(nuevoMedico);
		}

		[RelayCommand]
		public async Task EditarMedico()
		{
			if (MedicoSeleccionado != null)
			{
				_context.Medicos.Update(MedicoSeleccionado);
				await _context.SaveChangesAsync();
			}
		}

		[RelayCommand]
		public async Task EliminarMedico()
		{
			if (MedicoSeleccionado != null)
			{
				_context.Medicos.Remove(MedicoSeleccionado);
				await _context.SaveChangesAsync();
				ListaMedicos.Remove(MedicoSeleccionado);
			}
		}

		[RelayCommand]
		public async Task AgregarHorario()
		{
			if (MedicoSeleccionado != null)
			{
				var nuevoHorario = new Horarios
				{
					Dia = DiaSeleccionado,
					HoraInicio = HoraInicio,
					HoraFin = HoraFin,
					Medico = MedicoSeleccionado
				};
				_context.Horarios.Add(nuevoHorario);
				await _context.SaveChangesAsync();
				medicoSeleccionado.Horarios.Add(nuevoHorario);
			}
		}

		[RelayCommand]
		public async Task EliminarHorario(Horarios horario)
		{
			if (horario != null)
			{
				_context.Horarios.Remove(horario);
				await _context.SaveChangesAsync();
				MedicoSeleccionado.Horarios.Remove(horario);
			}
		}
	}
}
