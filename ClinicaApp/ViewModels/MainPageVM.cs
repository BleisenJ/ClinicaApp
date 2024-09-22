using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace ClinicaApp.ViewModels
{
	public partial class MainPageVM : ObservableObject
	{
		// Comandos para navegar a las diferentes secciones

		[RelayCommand]
		async Task AgendarCita()
		{
			// Lógica de navegación a la página de Agendar Cita
			await Shell.Current.GoToAsync("AgendarCitaPage");
		}

		[RelayCommand]
		async Task VerHistorial()
		{
			// Lógica de navegación a la página de Historial de Citas
			await Shell.Current.GoToAsync("HistorialCitasPage");
		}

		[RelayCommand]
		async Task GestionMedicos()
		{
			// Lógica de navegación a la página de Gestión de Médicos
			await Shell.Current.GoToAsync("MedicoPage");
		}

		[RelayCommand]
		async Task InventarioMedicamentos()
		{
			// Lógica de navegación a la página de Inventario de Medicamentos
			await Shell.Current.GoToAsync("InventarioMedicamentosPage");
		}
	}
}
