using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ClinicaApp.Modelos;
using ClinicaApp.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp.ViewModels
{
	// Hacer público
	public partial class HorarioVM : ObservableObject
	{
		private readonly ClinicaDbContext _context;

		[ObservableProperty]
		private ObservableCollection<Horarios> horarios;

		// Constructor sin parámetros para XAML
		public HorarioVM() { }

		// Constructor con ClinicaDbContext
		public HorarioVM(ClinicaDbContext context)
		{
			_context = context;
			CargarHorarios();
		}

		private async Task CargarHorarios()
		{
			Horarios = new ObservableCollection<Horarios>(await _context.Horarios.ToListAsync());
		}
	}
}
