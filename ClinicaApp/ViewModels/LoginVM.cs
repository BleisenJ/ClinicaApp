using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace ClinicaApp.ViewModels
{
	public partial class LoginVM : ObservableObject
	{
		[ObservableProperty]
		private string usuario;

		[ObservableProperty]
		private string password;

		[RelayCommand]
		private async Task Login()
		{
			// Lógica básica para autenticación
			if (Usuario == "Admin" && Password == "clinica123")
			{
				Preferences.Set("logueado", "si");
				Application.Current.MainPage = new AppShell();  // Redirige al Shell principal si el login es exitoso
			}
			else
			{
				await Application.Current.MainPage.DisplayAlert("Error", "Usuario o contraseña incorrectos", "Aceptar");
			}
		}
	}
}
